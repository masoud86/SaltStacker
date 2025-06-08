## Version 0.2.0
### 2025-06-07
#### New Features
- Seeded a default admin user and the Administrator role to support secure, role-based access to the API.

#### Improvements
- Renamed all instances of customer to account across the solution to ensure consistent terminology.
- Removed the Kitchen model and all associated domain entities to streamline the solution's architecture.
- Added a structured release notes file to document and track version changes.
- Cleaned up and extended user and role models for better maintainability and future support of scoped access control.
- Replaced dynamic hashing with a fixed password hash for the default admin user to stabilize EF Core migrations.