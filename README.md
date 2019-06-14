PANDA (Package Acceptance and National Delivery Application) web application from my SoftUni Web Basic Course

1. 1.Technological Requirements

• Use the **SIS.WebServer**

• Use the **SIS.MvcFramework**

• Use Entity Framework Core

1. 2.Database Requirements

The **Database** of the **PANDA** application needs to support **3 entities** :

### User

- **Id** - a **GUID**** String ****, Primary Key**
- **Username**** - **** a **** string **with** min length ****5** and **max length 20** ( **required** )

- **Email**** - **** a **** string **with** min length ****5** and **max length 20** ( **required** )
- **Password**** - ****a**  **string – hashed**  **in the database** ( **required** )
- **Packages** – a **Collection** of type **Packages**
- **Receipts** – a **Collection** of type **Receipts**

### Package

- **Id** - a **GUID**** String ****,**** Primary Key**

- **Description** - a **string**  **a**  **string** with **min length**** 5 **and** max length 20**(**required**)

- **Weight** - a **floating-point** number
- **Shipping**** Address **- a** string**
- **Status** - can be one of the following values (&quot; **Pending**&quot;, &quot; **Delivered**&quot;)
- **Estimated**** Delivery ****Date** - a **DateTime** object
- **RecipientId**** -****GUID foreign key (required)**
- **Recipient** - a **User** object

### Receipt

- **Id** - a **GUID**** String ****,**  **Primary Key**
- **Fee** - a **decimal** number
- **Issued**** On **- a** DateTime** object
- **RecipientId**** -****GUID foreign key (required)**
- **Recipient** - a **User** object
- **PackageId**** -****GUID foreign key (required)**
- **Package** – a **Package** object

The **Functionality**** Requirements **describe the functionality that the** Application** must support.

The **application** should provide **Guest** (not logged in) users with the functionality to:

- **Login**
- **Register**
- **View** the **Guest**** Index** page

The **application** should provide **Users** (logged in) with the functionality to:

- **Logout**
- **View** their **Packages**
- **View** their **Receipts**
- **View** all **Pending**** Packages**
- **View** all **Delivered**** Packages**
- **Deliver**** Packages**

### Users

**Users** have **Packages**. **Users** can **create**** Packages **. By default, the status of a package is &quot;** Pending **&quot;. When a** Package **is** delivered **, status is change from &quot;** Pending **&quot; to &quot;** Delivered **&quot; and** Receipt is created**.

**Users** can also **create**** Packages **for a specific** User**.

- They can also **view** all of his **Pending Packages**.
- They can also **view** all of his **Delivered Packages**.
- They can also **view** all of his **Receipt**.

### Packages

When **Packages** are **created** , they are **created** with a **Description** , a **Weight** , a **Shipping**** Address **and a** Recipient ****User**.

- Upon creation, the **Status** of a **Package** should be set to **Pending**.

##### Pending Packages

A **Pending**** Package **, can be** Delivered**by clicking on the [**Deliver**] button from the**Pending ****Packages** Page. At that moment the **Package**** Status **becomes &quot;** Delivered **&quot; and** receipt **is** generated **to the** User **for that** Package**

- **All**** Pending ****Packages** are presented on the **Pending**** Packages ****Page**.

##### Delivered Packages

- **All**** Delivered ****Packages** are presented on the **Delivered**** Packages ****Page**.

### Receipts

**Receipts** are just data entities. They are **created** when a **Package** is **Delivered** by its **Recipient**** User**.
A **Receipt** should be **created** with a **Package** and a **Recipient**** User**.

Upon creation, a **Receipt**&#39;s **Fee** should be **set** to the **Package**&#39;s **Weight**** multiplied**(\*) by**2.67**.

Upon creation, a **Receipt****&#39; **s** IssuedOn **should be set to the** current moment**.

1. 3.Security Requirements

The **Security Requirements** are mainly access requirements. Configurations about which users can access specific functionalities and pages.

- **Guest** (not logged in) users can access **Index** page and functionality.
- **Guest** (not logged in) users can access **Login** page and functionality.
- **Guest** (not logged in) users can access **Register** page and functionality.
- **Users** (logged in) can access **User**** LoggedIn ****Index** page and functionality.
- **Users** (logged in) can access **User**** Receipts** page and functionality.
- **Users** (logged in) can access **Logout** functionality.
- **Users** (logged in) can access the **Package**** Create** page and functionality.
- **Users** (logged in) can access the **Pending**** Packages** page and functionality.
- **Users** (logged in) can access the **Delivered**** Packages** page and functionality.
- **Users** (logged in) can access the **Package**** Deliver** functionality.

1. 4.Code Quality

Make sure you provide the best architecture possible. Structure your code into different classes, follow the principles of high-quality code ( **Single Responsibility** , **IoC** and **Interface Segregation** ). You will be scored for the **Code**** Quality **and** Architecture** of your project.

**NOTE:** The **Service Layer** is **required**

1. 5.Data Validation

- In case of invalid data during the **login** , redirect to &quot; **Users/Login**&quot;
- In case of invalid data during the **registration** , redirect to &quot; **Users/Register**&quot;
- In case of invalid data during the **package creation** , redirect to &quot; **Package/Create**&quot;