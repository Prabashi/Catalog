# Catalog

Following a C# .NET tutorial on YouTube: **.NET 5 REST API Tutorial - Build From Scratch With C#**

Version: **.NET 6**

IDE: **Visual Studio**

### MongoDB on Docker:
* Install Docker and verify from below command

  `docker version`
  
* Run the MongoDB image on Docker (Image will be pulled first)

  `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo`

* Verify the container is running
  
  `docker ps`
  
