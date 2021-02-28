
<img title="" src="Desktop/vue-powerbi-integration-master/Desktop/Yeni klasör/PowerBi/image/powerbilogo.png">
<br><br>

## Vue PowerBi Entegration
<br>

<img title="" src="Desktop/vue-powerbi-integration-master/Desktop/Yeni klasör/PowerBi/image/powerbiresult.PNG">
<br>

1. [What is PowerBi ?](#what-is-power-bi-?)
  
2. [What is Azure ?](#what-is-azure-?)
  
3. [Azure PowerBi Permissions](#azure-powerbi-permissions)
  
4. [Backend Usage](#backend-usage)
  
5. [Frontend Usage](#frontend-usage)

<br>

#### What is PowerBi ?

> Power BI is a business intelligence and analytics solution that uses SaaS * technology developed by Microsoft, enabling you to make powerful, interactive, visual reports and workspaces in a short time.
> 
> Day by day, the data obtained by organizations from various sources are increasing, and Power BI, which enables these stored data to be combined and restructured to make them readable and understandable to decision makers, is a solution that business analysts and senior managers can easily use with its simple and user-friendly interface.
> 
> One of the most important advantages of being developed by Microsoft is its integration with other Microsoft products.
> 
> You can share a report you have created on SharePoint, show it to users with the authorization you have done here, and you can also make your data more meaningful by using dozens of visuals in Power BI by moving your data in Excel or MS SQL Server to Power BI.

<br>

#### What is Azure ?

> Microsoft Azure is a large cloud platform with a wide range of features, meaning it is a customized version of the Windows Server operating system.
> 
> Azure Web Sites enable you to create enterprise-grade web applications. Using Azure technology; You have the chance to choose languages ​​such as ASP.NET, Java, Node.js, C #. So, in Microsoft's words, Azure speaks your language.
> 
> With Microsoft Azure technology, you can create new virtual machines or use your virtual machine from the existing image file.
> 
> When creating applications on Azure, we need a database to store our data, as in many applications. Different technologies are used in Windows Azure technology to store and manage these data. One of them is running SQL Server or other DBMS created with Windows Azure Virtual Machines. It is also possible to use NoSQL technology here. The user can create his own database to store the data, but the users should still manage it themselves. Windows Azure has provided three different methods to users in this job. These are SQL Databases, Tables and Blobs.
> 
> One of the biggest features of Azure mobile service is its cross platform. This means that you can create applications using the same infrastructure for IOS, Android, Windows Phone, Mac and Windows. Another important feature is that you can use C # and Node.js to create the back end system that is the end part of the application.

<br>

#### Azure PowerBi Permissions

- First go to portal.azure.com
  
- Then search for app service in the search section
  
- If we do not have an existing app service, we need to create a new app service.
  
- Then search for Azure Active Directory in the search bar, then select App Registiration from the side menu that opens.
  
- Select the app service you created from the screen that opens.
  
- Note the values ​​such as clientId, tenantId on the screen that opens, do not share this data.
  

- Then we will create a secret key of the application.
  
- Select the Certificates & secret menu, then create it with the new client secret. (Don't forget to write down the secret key)
 
<br>
<img title="" src="Desktop/vue-powerbi-integration-master/Desktop/Yeni klasör/PowerBi/image/clientsecret.PNG">
<br>

- We will set powerbi permissions on Azure as the last step.
  
- Select the Api Permissions menu, then select Add a Permission and select power bi service from the menu that opens.
  
- In the section that opens, delegated permission is selected and the areas you want to allow are selected.

<br>
<img title="" src="Desktop/vue-powerbi-integration-master/Desktop/Yeni klasör/PowerBi/image/permissions.PNG">
<br>

- With this process, the adjustments on the azure side are completed.
  
<br>

#### Backend Usage

- Open the backend codes in the project and set the parts you need to set in appsettings.json.
  

```c#
"PowerBI": {
    "ApplicationId": Your Client ID,
    "ApplicationSecret": Your Secret Key,
    "AuthorityUrl": "https://login.microsoftonline.com/Your Tenant ID/oauth2/token",
    "ResourceUrl": "https://analysis.windows.net/powerbi/api",
    "ApiUrl": "https://api.powerbi.com/",
    "EmbedUrlBase": "https://app.powerbi.com/"
  },
```

- To test the accuracy of your data, you can run the project and enter your desired power data and see the results.
  
<br>
<img title="" src="Desktop/vue-powerbi-integration-master/Desktop/Yeni klasör/PowerBi/image/swagger.PNG">
<br>

<br>

#### Frontend Usage

- Open the frontend project
  
- Run the following command to install dependencies
  

```
npm install
```

- Use the following command to run the project
  

```vue
npm run serve
```
