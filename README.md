# Terrains & Treasures Online Store 
<p align="center">
<img src="Images/t&amp;tLogo.png" width="200">
</p>
Online storefront for my D&amp;D Terrain, The purpose of this software is to move my tabletop gaming products business from Etsy to a dedicated, cloud-hosted web application. The store will allow me to have full control of the sales process and customize the user experience. It will handle product browsing, cart management, order placement, and account management. I will be building it using ASP.NET Core MVC along with third party APIs to handle payment and shipping 

## Functional Requirements 
The software lets the user register an account, browse product categories, add items to shopping cart, complete purchase, and check status of existing orders. Data will be stored using PostgreSQL and EF Core to connect it to the store. The following data will be stored in the database
  *	User details (ID, names, email, address, phone, registration date)
  *	Product details (ID, names, descriptions, prices)
  *	Order records (ID, user ID, product IDs, date/time)
  *	Inventory levels (ID, product ID, amount)
  *	Transaction records (ID, Order ID, date/time)
  *	Shipping information (ID, tracking numbers, carrier)

## Input, Processing, Output

### Input
Users will input product selections, personal information for accounts, and payment details. The product details and inventory levels will be inputted by me. The product details will be updated as new products come out through an admin screen, time permitting. Inventory levels will be updated automatically as products are purchased or updated in the admin screen.

### Processing
The system will handle updating inventory, order validation, and user authentication. Payment processing via a third-party API. I will be using either Stripe or Square for this functionality. Shipment tracking will be handled by storing carriers and tracking info in the database and providing direct links to the official tracking page.

### Output
There will be receipts created and automatic emails sent out upon order confirmation. There will also be an account dashboard where the user info will be displayed. There may be some administrative report functionality built in time permitting.

## Architecture Block Diagram
<img src="Images/Block_Diagram_T&T.png">

## Wireframes

### Home 
<img src="Images/Wireframe-Home.jpg" width="400">

### Product Detail
<img src="Images/Wireframe-Product-Detail.jpg" width="400">

### Cart
<img src="Images/Wireframe-Cart.jpg" width="400">

### Account 
<img src="Images/Wireframe-Account-Hub.jpg" width="400">

- User must be logged in to view Account
  
## User Stories 
1. As a customer, I want to browse the available terrain and other products so I can find items to purchase
2. As a customer, I want detailed information about the product so i can understand what it is and what it looks like
3. As a customer, I want to add products to my shopping cart so I can buy them and recive them in the mail
4. As an Administator, I want to manage product listings so i can add,update, or remove items
5. As an Administator, I want to Update inventory levels so that product availability remains accurate

## Use Cases

### UC-01: Register Account

Primary Actor: Customer 
Goal: Create a new user account 
Preconditions: Customer does not have account
Trigger: Customer selects create account 

#### Main Flow:
1. System displays registration form
2. Customer enters name, email,password,shipping address
3. Customer Submits form
4. system Validates Input
5. System Creates new user record in the database
6. System confirms registration

Alternate Flows:
A1. Email already exsists: Displays errors and requests new email
A2. Invalid or missing fields: Displays error about the particualr field(s)

Postconditions: Customer has an account

### UC-02: Browse Products 
Primary Actor: Customer
Goal: View products and categories.
Preconditions: Product catalog exsists 
Trigger: Customer navigates to home page or a category page 

#### Main Flow:
1. System displays a list of products
2. Customer scrolls product tiles
3. Customer selects product to view more details

Postconditions: Customer views products 

### UC-03: View Product Details

Primary Actor: Customer 
Goal: View details for a specific product
Preconditions: Product exists in the database
Trigger: Customer selects a product from the product listing

#### Main Flow:
1. System displays product title, images, description, and price
2. Customer reviews the details
3. Customer selects quantity (default = 1)
4. Customer selects Add to Cart

Alternate Flows:
A1. Product is out of stock: System disables Add to Cart and displays Out of Stock

Postconditions: Product is ready to be added to cart (or blocked if unavailable)

### UC-04: Add Item to Cart

Primary Actor: Customer 
Goal: Add one or more products to a shopping cart
Preconditions: Product exists in the database and is in stock
Trigger: Customer selects add to cart from product details page

#### Main Flow:
1. System creates a cart (if one does not already exist) for the current session/user
2. System adds the selected product and quantity to the cart
3. System updates cart totals
4. System displays confirmation and shows the updated cart

Alternate Flows:
A1. Requested quantity exceeds inventory: System adjusts quantity to available stock and displays an error
A2. Product already in cart: System increases the quantity and updates totals

Postconditions: Cart contains the selected item(s) and updated totals

### UC-05: Checkout and Place Order

Primary Actor: Customer 
Supporting Actor: Payment Provider
Goal: Submit payment and create an order record 
Preconditions: Customer has items in cart
Trigger: Customer clicks Proceed to Checkout

#### Main Flow:
1. System displays checkout summary (items, totals, shipping address)
2. Customer confirms order details
3. System creates a pending order record in the database
4. System redirects the customer to the payment provider checkout
5. Payment provider processes payment and returns a success/failure result
6. On success, system marks the order as paid and stores the payment reference ID
7. System displays an order confirmation and sends a confirmation email

Alternate Flows:
A1. Payment failed/canceled: System keeps order as unpaid/pending and displays an error message
A2. Cart is empty: System blocks checkout and returns customer to home
A3. Customer does not have an account: 
- The system displays a guest checkout option
- The system collects the customer’s email address and shipping information required to complete the order and send a receipt
- The system also provides an option to create an account before checkout 

Postconditions:
- Successful payment: Order exsist in dabase with status paid and recpeit email to customer
- Failed Payment: Order exsist in database with status unpaid

## UML Use Case Diagram
