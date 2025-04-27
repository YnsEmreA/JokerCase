This project is a mini roulette game prototype where users can place bets and select deterministic outcomes. The roulette always stops at the chosen target. This project was developed following Object-Oriented Programming (OOP) principles.

🎮 Controls and Gameplay Instructions
Placing a Bet:
Players choose a number on the roulette wheel to place their bet.

Selecting a Deterministic Outcome:
The selected number is set as the predetermined target where the roulette will stop after spinning.

Starting the Game:
After selecting a bet, players press the Spin button to start the roulette. The ball will slow down and land precisely on the selected number.

Special Keybindings:

Currently, there are no specific keyboard shortcuts. All interactions are handled via the UI buttons.

🛠️ Known Issues or Future Improvements
Known Issues:

The ball's physics simulation is currently script-based and not fully integrated with Unity's physics engine for realistic behavior.

Planned Improvements:

Implement more realistic ball physics using Unity’s Rigidbody and Colliders.

Develop a payout system based on betting odds.

Enhance the UI to display placed bets and outcomes more visually.

Ensure full mobile device compatibility and responsive design.


🧠 OOP Principles
The following OOP principles were applied during the development of this project:

Encapsulation:
Internal logic of classes was hidden; only necessary data and methods were exposed publicly (e.g., SpinManager class).

Inheritance:
Common behaviors were structured for possible reuse and scalability.

Polymorphism:
Flexible method structures were left open to support different types of spin systems in future updates.

Abstraction:
Complex processes were simplified so that users only interact with straightforward public methods.

SOLID Principles:

Single Responsibility Principle:
Each class was designed to have a single, clear responsibility.

Open/Closed Principle:
The project structure allows for adding new features without modifying existing code.

Dependency Inversion Principle:
Dependencies were managed through abstraction to ensure loose coupling between components.
