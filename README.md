# Elevator Simulation

The Elevator Simulation program is a console application written in C# that simulates the movement of elevators in a multi-floor building. The goal of the simulation is to efficiently move people between floors by managing multiple elevators.
Prerequisites

Docker: Make sure you have Docker installed on your machine. You can download and install Docker from the official website: https://www.docker.com/

# Running the Program

To run the Elevator Simulation program, follow these steps:

Clone the project from the GitHub repository:


    https://github.com/Keoroanthony/elevator-simulation/

Navigate to the project directory:

    cd elevator-simulation

Open a terminal or command prompt in the project directory.

Build and run the Docker container using Docker Compose:

    docker build -t elevator-simulation .
   
    docker run -it elevator-simulation

The program will start and prompt you to enter the floor you are currently on and the floor you want to go to. Follow the instructions in the console to interact with the elevators.

You can enter multiple elevator requests and observe the status of the elevators as they move between floors.

To quit the program, press 'q' and hit Enter.

<b>That's it! You have successfully run the Elevator Simulation program using Docker</b>.
