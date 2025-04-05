# Metrology Tools Project Overview

## Introduction
The Metrology Tools project is designed to enhance team collaboration and planning through two main applications: the Holiday Helper and the PI Planner. These tools aim to streamline processes related to vacation management and program increment planning, respectively, while also providing an unrestricted test mode for research and development purposes.

## Objectives
- **Improve Team Collaboration**: Facilitate better communication and planning among team members regarding vacation requests and project increments.
- **Enhance Planning Efficiency**: Provide tools that allow for effective management of resources and timelines.
- **Support R&D Activities**: Implement an unrestricted test mode to allow for experimentation and testing of new features without constraints.

## Architecture
The project is structured into three main components:

1. **Holiday Helper**: 
   - A web application that allows employees to submit vacation requests and check availability.
   - Key components include:
     - **Controllers**: Manage the logic for handling vacation requests.
     - **Models**: Define the data structure for vacation requests.
     - **Views**: Provide the user interface for interaction.

2. **PI Planner**:
   - A client-server application that assists in managing Program Increments (PIs) and integrates with tools like JIRA Align.
   - Key components include:
     - **Client**: A React-based front-end that provides a drag-and-drop interface for managing features.
     - **Server**: A Python-based backend that handles API requests and data synchronization.

3. **Unrestricted Test Mode**:
   - A service that allows developers to test features without the usual restrictions, facilitating innovation and experimentation.
   - Key components include:
     - **Test Controller**: Manages requests related to the test mode.
     - **Unrestricted Mode Service**: Ensures secure access to the test mode.

## Conclusion
The Metrology Tools project aims to provide a comprehensive solution for managing team collaboration and planning through its Holiday Helper and PI Planner applications. By incorporating an unrestricted test mode, the project also supports ongoing research and development efforts, ensuring that the tools remain effective and relevant in a dynamic work environment.