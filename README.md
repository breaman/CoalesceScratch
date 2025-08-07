This is just a simple starter coalesce project built with the following arguments
- dotnet new coalescevue -n Scratch.CoalesceScratch -o CoalesceScratch --TrackingBase --DarkMode --AuditLogs --UserPictures --ExampleModel --OpenAPI --Identity --LocalAuth

Since I primarily develop on a mac, I also added a basic aspire template around the project so that we could get sql server running

In order to get this running locally, you need to do the following:
- clone the repo
- open a terminal and navigate into the src\Scratch.CoalesceScratch.Web directory
  - run ```npm ci```
  - run ```npm run lint:fix```
  - run ```dotnet restore```
  - run ```dotnet coalesce```
- open the solution inside of your editor of choice and run the aspire\Scratch.CoalesceScratch.AppHost application