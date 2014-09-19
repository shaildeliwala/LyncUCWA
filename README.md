LyncUCWA
========

Overview
--------
A sample desktop application that uses UCWA, Lync's Web API.

The project started as a simple feasibility check and to see how UCWA authentication worked. It grew from that into a desktop application and is being actively worked on. All requests are made using a `System.Net.Http.HttpClient` object.

Features
--------
1. Authentication and login (as per flow described in the [documentation](https://ucwa.lync.com/documentation/GettingStarted-RootURL))

2. Outgoing presence ([makeMeAvailable](https://ucwa.lync.com/documentation/resources-makemeavailable))

3. Incoming presence ([contactPresence](https://ucwa.lync.com/documentation/Resources-contactPresence))

4. Instant messaging ([Outgoing](https://ucwa.lync.com/documentation/KeyTasks-Communication-OutgoingIMCall) and [Incoming](https://ucwa.lync.com/documentation/KeyTasks-Communication-IncomingIMCall))


Future Developments
-------------------
This is only a proof-of-concept application and not thoroughly tested. It will be refactored, modified, and tested a lot more. Following is some of the work that is being, or will be, done.

1. Using a proper architecture that separates the model/business layer to facilitate its reusability.

2. Building a portable, reusable library to process service responses and raise events.
 
3. Incorporating/testing features that UCWA exposes (instant messaging, audio conferencing, anonymous web chat, and search for a contact).
