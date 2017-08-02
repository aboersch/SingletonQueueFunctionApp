# SingletonQueueFunctionApp

Repo of an error with the singleton attribute for queuetrigger Azure Functions

At Startup CreateQueueItems creates 10 items in the queue => 1,2,3,4...

RunQueue is triggered by them and it should wait for each item to finish processing before launching the next one.

I would expect the log output to have the same number repeating but it is random.

Expected: 1,1,2,2...
Actual: 1,2,3...1,2,3...

Issue:

In a local Development environment using VS2017 Tooling and func CLI the QueueTrigger is not respecting the SingletonAttribute to prevent multiple queue items being processed in parallel.

Repo: https://github.com/aboersch/SingletonQueueFunctionApp

It also appears there is no lock file being created by the Consuming Function, only by the producer.

Windows 10.0.15063 Build 15063
Visual 2017 15.3.0 Preview 7.0
Azure Storage Emulator 5.1
Azure Function Tools for VS2017 0.2
