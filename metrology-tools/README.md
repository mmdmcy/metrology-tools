# Metrology Tools Project

## Overview
The Metrology Tools project is a lightweight web application that enhances team collaboration and planning through three integrated tools: Holiday Helper, PI Planner, and RD Test Mode. Built with ASP.NET Core and JavaScript, this application provides a simple yet effective dashboard for managing team resources.

## Applications

### Holiday Helper
The Holiday Helper application allows team members to manage vacation requests efficiently. Key features include:
- Vacation Request Management: Submit requests with employee ID, dates, and FTE percentage
- Employee Availability Tracking: Check when specific team members are available
- Competency Area Filtering: View availability across different competencies (Software, Physics, Mechanics, Electronics)

### PI Planner
The PI Planner application facilitates the management of Program Increments (PIs) across a 6-PI timeline. Features include:
- Feature Management: Create, view, and update features with story points
- Program Increment Organization: Assign features to specific PIs (1-6)
- Team Assignment: Track which teams are responsible for implementation
- Feature Status Tracking: Monitor progress from pending to completion

### RD Test Mode
The unrestricted test mode allows developers and physics engineers to test parameters beyond normal operational boundaries. This tool includes:
- Authentication System: Basic credentials check for secure access
- Parameter Adjustment: Modify test parameters outside normal ranges
- Test Execution: Simulate running tests with custom parameters
- Results Analysis: View test outcomes for further evaluation

## Technical Implementation

### Backend
- ASP.NET Core 8.0 with minimal API endpoints
- In-memory data storage with service pattern
- RESTful API design for all operations

### Frontend
- Pure JavaScript, HTML, and CSS (no frameworks)
- Tab-based navigation system
- Interactive forms for data submission
- Responsive design for usability

## Getting Started

1. Clone the Repository: git clone <repository-url>
2. Navigate to the Project Directory: cd metrology-tools
3. Run the Application: dotnet run
4. Access the Application: Open your browser and navigate to http://localhost:5179

## Usage Guide

1. Holiday Helper:
   - Fill out the vacation request form with employee details
   - Check availability by employee ID or competency area
   - View results in the panel below

2. PI Planner:
   - Add new features with the feature creation form
   - Select a PI to view all associated features
   - Use the move feature button to reassign features to different PIs

3. RD Test Mode:
   - Enter username and password to authenticate
   - Adjust test parameters using the sliders
   - Run the test to view results

## Project Structure

- Program.cs: Contains all application logic including API endpoints and services
- wwwroot/index.html: The main user interface with JavaScript functionality
- Models: VacationRequest and Feature classes for data representation
- Services: IHolidayService and IPlannerService for business logic

## Future Enhancements

- Database persistence for long-term data storage
- User authentication and authorization
- Excel import/export capabilities
- JIRA Align integration for PI planning
- Power BI dashboard for analytics

## Contribution Guidelines
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request detailing your changes.

## License
This project is licensed under the MIT License.

## Acknowledgments
This application was developed as a demonstration of ASP.NET Core minimal API capabilities with a simple frontend interface.