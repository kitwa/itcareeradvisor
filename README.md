Design Phase

Problem:
To predict student performance and recommend a suitable stream.

Objectives:

Specialization Recommendations: IT specialization area or career path tailored to each student's profile, academic performance, interests, and career goals.

Career Guidance: Comprehensive career guidance information, including job prospects, skill requirements, growth potential, and industry trends associated with the recommended specializations.


Visual Representation: Interactive dashboards, charts, and data visualizations enabling students to explore and analyse the underlying data and rationale behind the personalized recommendations.
Landing Page:
Main Page:

Application and Model Architecture:
User Interface Component: 
This component will provide a user-friendly interface for students to input their academic performance data, interests, career goals, and other relevant information.
The interface should be intuitive, easy to navigate, and accessible across different devices (desktop, mobile, etc.).
Technologies: Web-based application (HTML, CSS, JavaScript), mobile app (React Native, Flutter), or desktop application (Electron, JavaFX).
Database Component: 
This component will store and manage the various data sources required for the recommendation system, including student profiles, academic records, industry data, and potentially the generated recommendations.
A robust and scalable database management system (DBMS) will be required to handle the large volume of data.
Potential technologies: SQL databases (PostgreSQL, MySQL), NoSQL databases (MongoDB, Cassandra), or cloud-based solutions (Amazon RDS, Google Cloud SQL).


Data Processing and Feature Engineering Component: 
This component will handle the acquisition, cleaning, preprocessing, and feature engineering of the various data sources required for the recommendation system.
Data sources will include academic records, industry reports, job portals, and other relevant data.
Techniques like data cleaning, handling missing values, feature scaling, and one-hot encoding may be employed.
Technologies: Python (Pandas, NumPy, Scikit-learn), R, or other data processing libraries/frameworks.

Machine Learning/AI Models: 
This component will consist of one or more machine learning/AI models responsible for generating personalized recommendations based on the student's profile and data inputs.
Potential models will include collaborative filtering, content-based filtering, hybrid approaches, or other techniques suitable for recommendation systems.
Techniques like natural language processing (NLP) and sentiment analysis may also be employed to analyse textual data (e.g., job descriptions, student interests).
Technologies: Python (Scikit-learn, TensorFlow, Keras), R, or other machine learning/AI libraries/frameworks.

Presentation Component: 
This component will be responsible for presenting the personalized recommendations and relevant data insights to the students in an easily understandable and visually appealing manner.
Techniques like data visualization, interactive dashboards, and user-friendly reporting may be employed.
Technologies: specialized visualization tools (Power BI).

Application architecture:
Diagram in progress
Model architecture:



The above components will interact with each other to provide a seamless end-to-end experience for students seeking personalized career coaching and specialization recommendations. The specific implementation details, technologies, and integration approaches will be refined as the project progresses and more information becomes available.


Data Processing Workflow:

Data Acquisition: 
Collect and acquire data from various sources, such as academic records (e.g., transcripts, course information), industry reports, job portals, and other relevant data sources.
Potential data sources: University databases, public data repositories, web scraping, API integrations.
Data Cleaning and Preprocessing: 
Perform data cleaning tasks, such as handling missing values, removing duplicates, and addressing inconsistencies or errors in the data.
Apply preprocessing techniques like text normalization, tokenization, and stemming/lemmatization for textual data.
Feature Extraction and Engineering: 
Extract relevant features from the data sources that can be used as inputs for the machine learning/AI models.
Engineer new features by combining or transforming existing features, if necessary.
Techniques like one-hot encoding, feature scaling, and dimensionality reduction may be employed.
Data Transformation and Integration: 
Transform the processed data into a format suitable for the machine learning/AI models and the database.
Integrate the transformed data with the respective components (models and database) for analysis and storage.
Model Training and Evaluation: 
Train the machine learning/AI models using the processed and transformed data.
Evaluate the performance of the models using appropriate metrics (e.g., accuracy, precision, recall, F1-score).
Iterate and refine the models as needed to improve their performance.
Recommendation Generation: 
Utilize the trained models to generate personalized recommendations based on the student's profile and data inputs.
Store the generated recommendations in the database for future retrieval and presentation.
Data Visualization and Reporting: 
Analyse and visualize relevant data insights, such as industry trends, job market analysis, and recommendation-related metrics.
Generate user-friendly reports and dashboards to present the personalized recommendations and data insights to the students.


This data processing workflow outlines the general steps involved in acquiring, processing, and integrating data, training the machine learning/AI models, generating recommendations, and presenting the results to the students. The specific implementation details and technologies used may vary based on the project requirements and resources available.



Data processing workflow in progress
Entity Relation Diagram in progress
Database schema in progress





	












Data Dictionary
Personal Information Table:
Field Name
Description
Data Type
Constraints
StudentID
Unique identifier for each student
INT
PRIMARY KEY, AUTO_INCREMENT
FullName
Full name of the student
VARCHAR(255)
NOT NULL
DateOfBirth
Date of birth of the student
DATE
NOT NULL
Age
Age of the student
INT


Gender
Gender of the student
VARCHAR(50)


Nationality
Country of origin or citizenship
VARCHAR(100)


Email
Email address of the student
VARCHAR(255)
UNIQUE, NOT NULL
PhoneNumber
Contact number of the student
VARCHAR(50)


Address
Residential address of the student
TEXT


LanguagesSpoken
Languages the student can speak fluently
JSON


PersonalityTraits
Self-assessment of personality traits
JSON


LearningStyle
Preferred learning style
VARCHAR(100)


HobbiesAndInterests
Hobbies and non-academic interests
JSON









Academic Information Table:
Field Name
Description
Data Type
Constraints
StudentID
Unique identifier referencing PersonalInformation
INT
FOREIGN KEY REFERENCES PersonalInformation(StudentID)
CurrentDegreeProgram
Current degree program
VARCHAR(255)


YearOfStudy
Year of study
VARCHAR(50)


ExpectedGraduationDate
Expected graduation date
DATE


OverallGPA
Overall Grade Point Average
DECIMAL(3, 2)


MajorGPA
GPA specific to the major
DECIMAL(3, 2)


CompletedCourses
List of completed courses with grades
JSON


CurrentCourses
List of currently enrolled courses
JSON


FavoriteSubjects
Subjects or courses the student has enjoyed the most
JSON


LeastFavoriteSubjects
Subjects or courses the student has enjoyed the least
JSON


TechnicalSkills
List of technical skills
JSON


SoftSkills
List of soft skills
JSON


Certifications
Relevant certifications
JSON


Projects
Description of personal or academic projects
JSON


Internships
Details of past internships
JSON


ClubsAndOrganizations
Participation in student clubs or professional orgs
JSON


VolunteerExperience
Relevant volunteer work
JSON


FeedbackOnCurriculum
Student’s feedback on the current academic curriculum
TEXT



	


Career Preferences Table:
Field Name
Description
Data Type
Constraints
StudentID
Unique identifier referencing PersonalInformation
INT
FOREIGN KEY REFERENCES PersonalInformation(StudentID)
PreferredITSpecializations
Areas of interest within IT
JSON


CareerGoals
Career goals
TEXT


ShortTermGoals
Short-term career goals
TEXT


LongTermGoals
Long-term career goals
TEXT


PreferredIndustries
Industries of interest
JSON


PreferredJobRoles
Job roles of interest
JSON


WillingnessToRelocate
Openness to relocating for a job
BOOLEAN


PreferredWorkEnvironment
Preferred work settings
JSON


WorkLifeBalancePreference
Importance of work-life balance
VARCHAR(255)


PreferredMethodOfRecommendations
Preferred method of receiving recommendations
VARCHAR(255)


AdditionalComments
Any other information the student wishes to provide
TEXT







