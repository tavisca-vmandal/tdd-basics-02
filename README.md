# Console based calculator

## Console Calculator

You have to implement a console based calculator which can perform binary operations on decimal numbers. Your calculator will use the console as its 
display and the keyboard as its key pad. As the user presses keys on the keyboard, the display should update as per the keys pressed. The specifications
for your implementation are - 

### Specifications 
* The calculator should only support the following keys (excluding commas) - `0`, `1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `.`, `-`, `+`, `x`, `/`, `S`, `C`, `=`
* The calculator should support calculating 4 boolean operations - addition, subtraction, division and multiplication.
* Pressing C should reset the calcuator and display `0`.
* On error the calculator should display `-E-`.
* The calculator should support positive and negative decimal numbers.
* On starting the calculator should display `0`.
* Pressing `S` should toggle the sign (positive or negative) of the number from.

The basic starter code for your solution has been provided along with the wiring of the calcuator to the console. You can add your implementation accordingly. 


### Examples
**1.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| 0 | 10 |
| + | 10 |
| 2 | 2 |
| = | 12 |


**2.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| 0 | 10 |
| / | 10 |
| 0 | 0 |
| = | -E- |


**3.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 0 | 0 |
| 0 | 0 |
| . | 0. |
| . | 0. |
| 0 | 0.0 |
| 0 | 0.00 |
| 1 | 0.001 |


**4.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| 2 | 12 |
| + | 12 |
| 2 | 2 |
| S | -2 |
| S | 2 |
| S | -2 |
| = | 10 |

**5.**

| Keys Pressed | Updated Display |
| ------------ | --------------- |
| 1 | 1 |
| + | 1 |
| 2 | 2 |
| + | 3 |
| 3 | 3 |
| + | 6 |
| = | 12 |

