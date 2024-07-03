# PROJECT OVERVIEW
#### This project is about building an online agency website for selling or renting properties

#### I’m Dominique Kiboko. I’m a Full Stack Developer / .NET developer. I find C# a great language to use and it’s also backed by a great ecosystem, I love solving  problems.

# BACKEND

dotnet 5.0.2
dotnet new sln  #in folder
dotnet new webapi -o API
dotnet sln add API
cd API

### Generate a self-signed certificate  (NB: disable ssl certificate verification in postman)
dotnet dev-certs https --trust

### INSTALL ENTITY FRAMEWORK SUPPORTING YOUR TYPE OF DATABASE
Microsoft.EntityFrameworkCore.Sqlite 5.0.2
### INSTALL EXTENTION FOR SQLITE TO SEE SQLITE DATABASE

### INSTALL DOTNET EF GLOBALLY
dotnet ef --version
dotnet tool install --global dotnet-ef --version 5.0.2

### INSTALL THE DESIGNER
Install Microsoft.EntityFrameworkCore.Design 5.0.2

### CREATE MIGRATIONS
dotnet ef migrations add InitialCreate -o Data/Migrations
dotnet ef migrations add AddMorefieldsUsers
dotnet ef migrations remove  ##remove previous migration

#### To delete db and recreate with all migrations
dotnet ef database drop
dotnet ef database update

### UPDATE DATABASE
dotnet ef database update

# FRONTEND

### Install Node
if using nvm then nvm install v20.10.0

### Install angular CLI
npm install -g @angular/cli
https://angular.io/cli

Angular 12.0.2
ng new client
Choose CSS

### ADD BOOTSTRAP 5
source: https://colinstodd.com/posts/code/how-to-install-bootstrap-in-angular.html

#### From the root of your project you need to install Bootstrap 5, and Popper.js which is used for dropdown menu’s and other JavaScript sort of things:

npm install bootstrap@next popper.js --S

#### Update your angular.json file with the same code snippet below in two places: Underneath "build" and "test":

 "styles": [
   "src/styles.css",
   "./node_modules/bootstrap/dist/css/bootstrap.min.css",
 ],
 "scripts": [
   "./node_modules/popper.js/dist/umd/popper.min.js",
   "./node_modules/bootstrap/dist/js/bootstrap.min.js"
 ]

### UPLOAD IMAGE
 https://cloudinary.com/ or imgix.com


## ANGULAR COMMANDS

#### Components (nav component)
ng g c nav --skip-tests

#### Services
ng g s account --skip-tests

#### modules
ng g m shared --flat

#### guards
ng g guard auth --skip-tests
ng g guard prevent-unsaved-changes --skip-tests

#### interceptors
ng g interceptor --skip-tests

#### NB for the component to be everywrere you need to put it in app.component.html wg: the loading spinner

### BOOTSTRAP THEME
npm install bootswatch

### BACKUP DB
I will need a cron job or a task that will backup my database to s3 aws everyday

##### The frontend can be host on netflify



#### Insert sample
INSERT INTO Properties (Id, Price, BathRooms, BedRooms, Garage, PropertyType, Description, City, Country, Created, AppUserId)
VALUES (2, 1000, 2, 2, 1, 'house', 'Lorum Ipsum description on my head', 'kinshasa', 'SouthAfrica', '2021/12/12',1);

### File Uplaod ngx
npm install ng2-file-upload --save

### Spinner
ng add ngx-spinner

### photo gallery
@kolkov/ngx-gallery

### model
ng add ngx-bootstrap  --component modals


### Time
npm install ngx-timeago



### ROLES DB

# SQLite
INSERT INTO AspNetRoles (Name, NormalizedName, ConcurrencyStamp) VALUES ("admin", "ADMIN", "86f8fec3-e753-4239-94c6-f5f7f8cf2a7e");

UPDATE AspNetRoles SET ConcurrencyStamp = "86f8fec3-e753-4239-94c6-f5f7f8cf2a8r" WHERE Id = 3
UPDATE AspNetRoles SET Name = "Member" WHERE Id = 1;
UPDATE AspNetRoles SET Name = "Agent" WHERE Id = 2;
UPDATE AspNetRoles SET Name = "Admin" WHERE Id = 3;

-- SQLite
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (2, 3);

### Docker - Postgres
#### Install docker
https://docs.docker.com/docker-for-windows/install/

#### Get Postgres Image
https://hub.docker.com/_/postgres

#### Run locally
docker run --name dev -e POSTGRES_USER=kibokouser -e POSTGRES_PASSWORD=KibokoHouse1502@ -p 5432:5432 -d postgres:latest 

#### postgres tools
https://www.pgadmin.org/


#### add postgres add-ons to heroku

#### Heruku tools
https://devcenter.heroku.com/articles/heroku-cli#verifying-your-installation
https://elements.heroku.com/buildpacks/jincod/dotnetcore-buildpack

### heruku dotnet build pack
https://elements.heroku.com/buildpacks/jincod/dotnetcore-buildpack
heroku buildpacks:set jincod/dotnetcore

heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack#preview



#### configure environment variable in heroku for production
heroku config:set ASPNETCORE_ENVIRONMENT=Production
heroku config:set TokenKey=nFDEkkT6xrg9DzBfg5na8vNtVTEBcvtf
nFDEkkT6xrg9DzBfg5na8vNtVTEBcvtf

### generate token
https://passwordsgenerator.net/

### publish app to heroku
ng build
git push heroku master 


### add ssl to domain
https://www.ssls.com/knowledgebase/how-to-install-an-ssl-certificate-on-heroku/


### after renaming app in heroku
git remote rm heroku
heroku git:remote -a kibokohouse



# UPDATE TO .NET 7

# UPDATE TO ANGULAR 14

 https://update.angular.io/?v=12.0-14.0

 ng update @angular/core@13 @angular/cli@13 --force


 Change Defaut Date Time to DateTime.UtcNow;

# DEPLOYEMENT

# ADDED DOCKER FILE AND BUILD
 ### In API folder Run this conmmand to build the image
 
  docker build -t dominichdocker/kibokohouse .

 #### run docker

  docker run --rm -it -p 8080:80 dominichdocker/kibokohouse:latest

 #### push to docker so that we can access from the cloud flateform we are going to be using

 docker push dominichdocker/kibokohouse:latest


# Update deployment to fly.io

https://fly.io/docs/hands-on/install-flyctl/

  ### install on windows 
  powershell -Command "iwr https://fly.io/install.ps1 -useb | iex"

  fly auth login


# fly launch (run this command in main folder)
fly launch --image dominichdocker/kibokohouse:latest

# Configure Fly Env for .NET
  Open fly.toml, After [Build] add 
  [Env] 
    ASPNETCORE_URLS="http://+:8080"
    CloudinarySettings__ClousName="dvggn7rcu"
    CloudinarySettings__ApiKey="213313646752296"
  Then in Docket file expose port 8080

# Configure fly Secret Env ()add the API Secret without double quote marks

  fly secrets list 
  fly secrets set CloudinarySettings__ApiSecret=XXXXXXXXXXXXXXXXXXXX
  fly secrets set TokenKey=XXXXXXXXXXXXXXX

 # generate password 
 https://delinea.com/resources/password-generator-it-tool


 Nz8CQpGBjHCJvfYUSDsJwIKYNrWtnA9s

 ### rebuild the docker image in API and push to docket hub 

# deploy to flyctl when ready
fly deploy  or fly deploy --local-only


# docker to github
https://github.com/docker/build-push-action


