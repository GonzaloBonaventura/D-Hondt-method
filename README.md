# D’Hondt Senate Simulator

A C# console application that simulates the D’Hondt method for proportional seat allocation in parliamentary or senate elections. Enter parties and votes, set the number of seats, and the program computes how many seats each party wins using the official D’Hondt formula.

---

## Features

- Interactive input for political parties and vote totals
- Customizable number of seats
- Real-time calculation following the D’Hondt method
- Clear seat-by-seat output for educational interpretation

---

## How the D’Hondt Method Works

1. Each party starts with 0 seats.
2. Their total votes are divided by (current seats + 1).
3. The highest quotient receives the next seat.
4. Steps continue until all seats are allocated.
5. A list is shown with each seat awarded and running totals.

This system is widely used for proportional representation in elections around the world.
