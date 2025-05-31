# 🧂 SaltStacker

**SaltStacker** is a modern, open-source API built to solve real problems in the food tech industry, from ingredient and recipe management to price tracking, nutrition analysis, and reporting.

It’s designed with kitchens, ghost kitchens, catering platforms, and restaurant software in mind, whether you’re building an internal tool, a SaaS platform, or looking to enhance your current system with rich, structured food data.


## 🧠 Why It Exists

There’s a gap between food industry needs and accessible developer tools.

- Most systems are outdated or expensive
- New food businesses often lack technical infrastructure
- Many kitchens still run on spreadsheets

**SaltStacker** aims to fix that, with a clean, modern, extensible API that **developers can trust and food businesses can rely on**.


## 🛠️ Tech Stack

- **.NET 9 (ASP.NET Core Web API)**
- **Entity Framework Core**
- **SQL Server**
- **JWT-based token authentication**
- **Swagger**

Planned:
- **Docker & CI/CD**
- **Rate limiting & key-based auth**


## 📦 Getting Started

Clone the repo and get it running locally:

### bash
git clone https://github.com/masoud86/SaltStacker.git  
cd SaltStacker

### Apply migrations
dotnet ef database update -p SaltStacker.Data -s SaltStacker.Api

### Run the API
cd SaltStacker.Api  
dotnet run

Use the /customer/login endpoint to get a JWT and explore protected routes.

##🤝 Contribute & Collaborate
SaltStacker is fully open-source and welcomes contributions!

Whether you’re a backend dev, food-tech founder, or just want to help shape something meaningful:

- Suggest features
- Report bugs
- Improve docs
- Submit pull requests
- Or just star ⭐ the project and follow along

Your ideas and insights are welcome.

## Final Note
SaltStacker is built with real-world use cases in mind, not just as a personal playground, but as a foundation that can power actual products in the food industry.
It will grow steadily, with stability and usefulness as top priorities.
Thanks for stopping by! Follow the project, open issues, or just say hi. Let’s build something valuable together.
