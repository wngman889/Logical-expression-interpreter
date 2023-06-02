# Logical-expression-interpreter
Application for parsing logical expressions.
The program gets its parameters from the command line. It allows building and using a collection of logical functions.
# The application is made with the Reverse Polish notation(RPN) algorithm
Each function is defined as a named logical expression composed of the basic logical operations AND, OR, and NOT or other user-entered functions.
The input logic function checks for errors. Basic operations have a predefined priority that can be changed by using parentheses. Writing (when defining a new function) and reading (when starting the program) user-defined functions from a file.Solving a function for given parameters.
A hierarchy of classes representing the operands and operators through which a tree representing the logical expression can be constructed. It has also a function which is constructing a truth table for the different logical expressions.
