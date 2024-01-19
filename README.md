# Crestron NVX

## Overview
This project was developed as a part of a technical quest fot the interview process. The purpose of the project is to create a C# application that interacts with Crestron NVX devices, providing authentication, device data retrieval and session management.

### Key Features
- **Authentication:** Interaction with Crestron NVX devices to authenticate users.
- **Device Data Retrieval:** Retrieval of device data, including resolution and sync status.
- **Session Management:** Ability to start and end connections with Crestron NVX devices.

### Technical Choices

- **HttpClient:** Utilized `HttpClient` for handling HTTP requests to interact with the Crestron NVX devices.
- **MemoryCache:** Leveraged `Microsoft.Extensions.Caching.Memory` for caching responses and managing session data.

### Code Structure

- The code is organized into a class named `NvxApiManager` responsible for managing interactions with Crestron NVX devices.
- As per the API requirements, this code first create a session with the device with given IPAddress. Once session established, it then authenticate the session using username and password. If authenticated it will show the Horizontal and Vertical resolution of the device with the current sync, if detected.
- The http requests handled as described in the cited document.

## Usage

1. Launch the application.

2. Enter the IP address, username, and password of your Crestron NVX device.

3. Click the "Login" button to start a session.

4. Explore the device resolution and Current Sync Detected.

5. Click the "Logout" button to end the session.

## Challenges and Learnings

### Challenges Faced

- **Asynchronous Programming:** Incorporating asynchronous programming was challenging, especially when dealing with HTTP requests. Ensuring proper handling of async operations and avoiding deadlocks required careful consideration.

- **API Interaction:** Understanding the nuances of the Crestron NVX API and adapting the application to handle its specifics presented a learning curve. Adhering to the API documentation and interpreting responses accurately were crucial aspects.

### Learnings

- **MemoryCache Usage:** Learned about the effective use of `MemoryCache` for caching responses and managing session data. This allowed for improved performance and reduced redundant requests.

## Conclusion

This project served as a valuable opportunity to apply and strengthen my skills in .NET development, API interaction, and asynchronous programming. Facing and overcoming challenges in areas such as error handling and API integration provided valuable learning experiences.

The project demonstrated my ability to create a functional application that effectively communicates with external devices, showcasing my proficiency in handling HTTP requests and providing a user-friendly interface for authentication and data retrieval.

The solution is scalable, modular and user friendly.

Reference:
Authentication | API for DM NVX® AV Encoders and Decoders Manual. (n.d.). https://sdkcon78221.crestron.com/sdk/DM_NVX_REST_API/Content/Topics/Authentication.htm
