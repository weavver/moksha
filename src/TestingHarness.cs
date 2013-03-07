using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Weavver.Data;
using System.Threading;

using System.Diagnostics;
using Weavver.Testing.Attributes;
using System.Threading.Tasks;

namespace Weavver.Testing
{
     public partial class TestingHarness : Form
     {
          Assembly testAssembly = null;
//-------------------------------------------------------------------------------------------
          public TestingHarness()
          {
               Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

               InitializeComponent();
          }
//-------------------------------------------------------------------------------------------
          private void TestingHarness_Load(object sender, EventArgs e)
          {
               webBrowser1.Navigate("about:blank");
               WebBrowserStreamWriter wsw = new WebBrowserStreamWriter(webBrowser1);
               Console.SetOut(wsw);

               dataGridView1.AutoGenerateColumns = false;

               if (TestingContext.Arguments.Length > 0)
               {
                    testAssembly = Assembly.LoadFile(TestingContext.Arguments[0]);
               }
               else
               {
                    testAssembly = Assembly.GetExecutingAssembly();
               }

               var testTypes = (from x in testAssembly.GetTypes()
                                where LinqTestHelpers.HasAttribute(typeof(StagingTest), x)
                                || LinqTestHelpers.HasAttribute(typeof(ManualTest), x)
                                select x);

               foreach (var type in testTypes)
               {
                    MethodInfo[] methods = type.GetMethods();
                    var matchedMethods = (from y in methods
                                          where y.GetCustomAttributes(typeof(StagingTest), true).Count() > 0
                                          || y.GetCustomAttributes(typeof(ManualTest), true).Count() > 0
                                          select y);

                    foreach (var method in matchedMethods)
                    {
                         var newTest = new System_Tests();
                         newTest.Status = "Untested";
                         newTest.Path = type.FullName + "." + method.Name;
                         newTest.IsStagingTest = (method.GetCustomAttributes(typeof(StagingTest), true).Count() > 0);
                         TestingContext.Tests.Add(newTest);
                    }
               }

               BindData();

               tbSearch.Focus();

               if (TestingContext.Arguments.Length > 0)
               {
                    Console.WriteLine("Running tests..");
                    ThreadPool.QueueUserWorkItem(o => RunTests());
               }
          }
//-------------------------------------------------------------------------------------------
          private void BindData()
          {
               var sortedTests = from x in TestingContext.Tests
                                 orderby x.Path ascending
                                 select x;

               if (!String.IsNullOrEmpty(tbSearch.Text))
               {
                    dataGridView1.DataSource = sortedTests.Where(x => x.Path.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
               }
               else
               {
                    dataGridView1.DataSource = sortedTests.ToList();
               }
          }
//-------------------------------------------------------------------------------------------
          private void RunAllTests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               //ThreadPool.QueueUserWorkItem(o => RunTests());
          }
//-------------------------------------------------------------------------------------------
          private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
               System_Tests test = (System_Tests)dataGridView1.Rows[e.RowIndex].DataBoundItem;

               QueueTestRun(test);

               dataGridView1.Rows[e.RowIndex].Selected = false;
          }
//-------------------------------------------------------------------------------------------
          private void QueueTestRun(System_Tests test)
          {
               ThreadPool.QueueUserWorkItem(o => RunTest(test));
          }
//-------------------------------------------------------------------------------------------
          public void RunTests()
          {
               var sortedTests = from x in TestingContext.Tests
                                 where x.IsStagingTest
                                 orderby x.Path ascending
                                 select x;

               sortedTests.ToList().ForEach(
                    x =>
                    {
                         try
                         {
                              RunTest(x);
                         }
                         catch (Exception ex)
                         {
                              Console.WriteLine(ex.ToString());
                         }
                    }
                    );
          }
//-------------------------------------------------------------------------------------------
          private void RunTest(System_Tests test)
          {
               //test.StartTime = DateTime.UtcNow;
               //Stopwatch sw = new Stopwatch();
               //sw.Start();
               test.EndDateTime = null;
               test.StartDateTime = DateTime.UtcNow;
               test.Status = "Running";

               string typePath = test.Path.Substring(0, test.Path.LastIndexOf("."));
               string methodName = test.Path.Substring(test.Path.LastIndexOf(".") + 1);

               var testType = (from x in testAssembly.GetTypes()
                                where x.FullName == typePath
                                select x).FirstOrDefault();

               if (testType == null)
               {
                    test.Status = "Missing";
                    return;
               }

               MethodInfo testMethod = testType.GetMethods().Where(x => x.Name == methodName).FirstOrDefault();

               object o = Activator.CreateInstance(testType);
               test.Log += " -> " + testMethod.Name + "()";
               try
               {
                    var SetUpMethod = LinqTestHelpers.GetMethodForAttribute(testType, typeof(TestFixtureSetUpAttribute));
                    if (SetUpMethod != null)
                         SetUpMethod.Invoke(o, null);

                    testMethod.Invoke(o, null);

                    test.Status = "Passed";
               }
               catch (Exception ex)
               {
                    test.Status = "Failed";
                    test.WriteLog(" ---> " + System.Web.HttpUtility.HtmlEncode(ex.ToString()));
               }
               finally
               {
                    try
                    {
                         var TearDownMethod = LinqTestHelpers.GetMethodForAttribute(testType, typeof(TestFixtureTearDownAttribute));
                         if (TearDownMethod != null)
                              TearDownMethod.Invoke(o, null);
                    }
                    catch { }
               }

               //sw.Stop();

               test.LastRunDateTime = DateTime.UtcNow;
               test.EndDateTime = DateTime.UtcNow;
               

               test.WriteLog("<span style='color:red'>-----<br />Test ended.</span>");
          }
//-------------------------------------------------------------------------------------------
          private void timerRefreshDataGridView_Tick(object sender, EventArgs e)
          {
               // TODO: USE TIMER APPROACH IN THE TEST OBJECT TO KEEP THE RUN TIME COLUMN UPDATED
               dataGridView1.Refresh();
          }
//-------------------------------------------------------------------------------------------
          private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
          {
               DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
               System_Tests test = (System_Tests)row.DataBoundItem;
               if (test == null)
                    return;
               switch (test.Status)
               {
                    case "Failed":
                         row.DefaultCellStyle.BackColor = Color.LightCoral;
                         break;

                    case "Passed":
                         row.DefaultCellStyle.BackColor = Color.LightGreen;
                         break;

                    case "Running":
                         row.DefaultCellStyle.BackColor = Color.LightBlue;
                         break;    

                    default:
                         row.DefaultCellStyle.BackColor = Color.LightGray;
                         break;
               }
          }
//-------------------------------------------------------------------------------------------
          private void dataGridView1_Click(object sender, EventArgs e)
          {

          }
//-------------------------------------------------------------------------------------------
          private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
          {
               if (e.RowIndex >= 0)
               {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    System_Tests test = (System_Tests)row.DataBoundItem;

                    webBrowser1.Navigate("about:blank");
                    webBrowser1.Document.Write(test.Log);
               }
          }
//-------------------------------------------------------------------------------------------
          private void tbSearch_TextChanged(object sender, EventArgs e)
          {
               BindData();
          }
//-------------------------------------------------------------------------------------------
          Task task3;
          CancellationTokenSource tokenSource = new CancellationTokenSource();
//-------------------------------------------------------------------------------------------
          private void RunAutomatically_CheckedChanged(object sender, EventArgs e)
          {
               if (RunAutomatically.Checked)
               {
                    tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;

                    task3 = new Task(() => RunPublisher(token), token, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
                    task3.Start();
               }
               else
               {
                    tokenSource.Cancel();
               }
          }
//-------------------------------------------------------------------------------------------
          private void RunPublisher(CancellationToken  ct)
          {
               var sortedTests = from x in TestingContext.Tests
                                 where x.IsStagingTest
                                 orderby x.Path ascending
                                 select x;

               sortedTests.ToList().ForEach( x => x.Status = "Untested");

               // Check if new SVN version of code

               // If so, Update Staging SVN

               // Re-compile all the projects

               // Restart the Testing Harness

               // -> Have it continue to Run publishers

               // Run the tests
               sortedTests.ToList().ForEach(
                    x =>
                    {
                         if (!ct.IsCancellationRequested)
                         {
                              try
                              {
                                   RunTest(x);
                              }
                              catch (Exception ex)
                              {
                                   //
                              }
                         }
                    }
                    );

               if (ct.IsCancellationRequested)
               {
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
