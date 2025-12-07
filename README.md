ASP.NET Core Microservices E-Commerce

A complete microservices-based e-commerce application built using ASP.NET Core, applying real-world enterprise patterns for scalability, security, and loose-coupling between services.

🏗️ Architecture

✔ Microservices Architecture
✔ API Gateway (Ocelot)
✔ IdentityServer6 Authentication & Authorization
✔ Event-Driven Communication (Azure Service Bus & RabbitMQ)
✔ Repository Pattern + DTOs + AutoMapper
✔ CI-Ready Modular Solution Structure

🧩 Microservices Included
Service	Technology	Responsibility
🛍 Products API	EF Core + SQL Server	Manage catalog products (CRUD, details)
🛒 Shopping Cart API	EF Core + Sync Communication	Manage user cart actions
🎟 Coupons API	EF Core	Discount engine & code validation
📦 Orders API	Azure Service Bus	Checkout & order processing
💳 Payments API	Azure Service Bus + RabbitMQ	Payment verification & update outcomes
📧 Email API	Queue Consumer	Send confirmation & notification emails
🔐 Security
Feature	Implementation
Authentication	IdentityServer6
Authorization	API Scope-based Access
Token Inspection	Secure Token Flow (Bearer Token)
📡 Communication Flows
Flow	Protocol
UI ⇒ Gateway ⇒ Microservices	REST / HTTP
Services ⇒ Services	Messaging Bus (Topic/Queue & Exchange Routing)
☁️ Cloud Integrations

Azure Service Bus
(Topic Sender + Subscription Consumer)

Azure Blob Storage
(Upload / Delete product images)

RabbitMQ
(Fanout / Direct / Topic Exchange demos)

🧪 Testing & Quality

✔ Supports Unit Testing & Integration expansions
✔ Clean separation following SOLID principles

🛠️ Technologies Used

ASP.NET Core 8 MVC & Web API

Entity Framework Core

Dapper (optional patterns)

AutoMapper

SQL Server

Ocelot API Gateway

IdentityServer6

Azure Service Bus Messaging

RabbitMQ Messaging

HTML, CSS, Bootstrap for UI
