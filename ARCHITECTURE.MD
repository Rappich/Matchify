graph TD
    RN[React Native Mobile App]
    API[ASP.NET Core Web API]
    DB[MongoDB Database]
    SR[SignalR Hub (Real-Time)]

    RN -- HTTP API calls --> API
    API -- Reads/Writes --> DB
    RN -- SignalR connection --> SR
    API -- SignalR communication --> SR
    SR -- Push match notifications --> RN

    style RN fill:#61dafb,stroke:#333,stroke-width:2px
    style API fill:#512bd4,stroke:#333,stroke-width:2px,color:#fff
    style DB fill:#4DB33D,stroke:#333,stroke-width:2px,color:#fff
    style SR fill:#ff3c00,stroke:#333,stroke-width:2px,color:#fff
