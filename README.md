Weavver Moksha - Release & Testing Harness
========
License: MIT  
Status: Alpha  
Author: Mitchel Constantin <mythicalbox@weavver.com> / Weavver, Inc.
Company Website: www.weavver.com  

Moksha is an alternative unit testing tool to NUnit and MSTest. I ran into many limitations using these tools.

For example blocking on long running tests. With Moksha, you can run several tests side by side.

Root of the word: http://en.wikipedia.org/wiki/Moksha

Usage:

1. Build the project using "nant build".

2. Run moksha.exe against your test library using this command line: "/testlib=C:\testlib.dll"

3. Reference the Interface project in your unit testing library and mark your methods as "ManualTest" to have them automatically loaded into Moksha.

4. Use the Assert class to test data in your units. Failed tests or thrown exceptions will show the test as failed/red in Moksha.

Tip: Set the Debug Start Action/Options to run moksha when you press F5 in Visual Studio to make testing easier/more seamless.

There are more features, but you'll have to poke around for now and find them.. Try looking at the "StagingTest", "TestFixtureSetUp", and "TestFixtureTearDown" attributes.

TODO: Add library wide SetUp/TearDown methods that are invoked on Moksha start up/exit. (Useful for session prep that all tests can take part in, as opposed to per-class set-up/tear downs).
Desired features in the future: Automatic mode for use on a build server. Statistic tracking.