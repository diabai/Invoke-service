# Invoke service

The current application is a simple web service using ``ASP.net``. It extracts features from the headers of a ``HTTP GET`` request. The following data from the headers will be displayed for each legitimate request:

  -   Status code
  -   Protocol version
  -   Server 
  -   Date file was last modified
  -   Character set
  -   Content type
  -   Content length
  
  
The headers were randomly chosen, it was just for the purpose of demonstrating how it is done. 
Launch the app, enter a url of your choice, and examine the headers returned in ``XML`` format.
