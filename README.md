<h1>NodeTree</h1>
    <p>NodeTree is a .Net 6-based project that implements a tree structure allowing users to add, retrieve, and manage tree nodes. Additionally, NodeTree allows for easy error handling and reporting.</p>
    <h2>Project Structure</h2>
    <p>The project consists of five main elements: Handler, Repository, Service, Request, and Response patterns. </p>
    <ul>
        <li><strong>Handler:</strong> handles user requests and mediates between the user and the rest of the project.</li>
        <li><strong>Repository:</strong> is responsible for storing data and providing access to it.</li>
        <li><strong>Service:</strong> provides the business logic and performs operations on data.</li>
        <li><strong>Request:</strong> represents a user request and contains all the necessary data.</li>
        <li><strong>Response patterns:</strong> represent design patterns related to the way server responses are created and processed.</li>
    </ul>
    <p>These design patterns were implemented to increase project readability and ease of maintenance. The following design patterns were used:</p>
    <ul>
        <li><strong>Handler pattern:</strong> allows for easy addition of new functionalities to the project.</li>
        <li><strong>Repository pattern:</strong> provides easy access to data and separation of business logic from the way it's stored.</li>
        <li><strong>Service pattern:</strong> provides separation of business logic from the way user requests are handled.</li>
        <li><strong>Request-Response pattern:</strong> allows for easy transmission of data between the user and the server.</li>
    </ul>
    <h2>Unit Tests</h2>
    <p>The project also includes unit tests in a separate project that uses NUnit and Moq libraries with in-memory database for testing. These unit tests help ensure the correctness and reliability of the project.</p>
    <h2>Running the Project</h2>
    <p>To run the project, compile it in Visual Studio or build it from the command line. Then, the application can be run from Visual Studio or the executable file. To use the project on a different server, configure the appropriate database connections.</p>
    <h2>Summary</h2>
    <p>NodeTree is a .Net 6-based project that implements a tree structure, allowing users to add, retrieve, and manage tree nodes. The project was designed with Handler, Repository, Service, Request, and Response patterns to increase its readability and ease of maintenance. The project also includes unit tests in a separate project using NUnit and Moq libraries with in-memory database for testing, which helps ensure the project's correctness and reliability.</p>
