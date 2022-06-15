# About

Next level after `BasicConsoleApp1` project

- Application icon
- Program class is a `partial` class
  - Main class in root of project
  - Secondary in `Classes` folder for *stuff* that is for
    - Setup
    - Code to keep root code clean

`[ModuleInitializer]` method is in Classes.Program

In short `[ModuleInitializer]`

- Enable libraries to do eager, one-time initialization when loaded, with minimal overhead and without the user needing to explicitly call anything
- One particular pain point of current static constructor approaches is that the runtime must do additional checks on usage of a type with a static constructor, in order to decide whether the static constructor needs to be run or not. This adds measurable overhead.

Some requirements are imposed on the method targeted with this attribute:

1. The method must be static.
2. The method must be parameterless.
3. The method must return void.
4. The method must not be generic or be contained in a generic type.
5. The method must be accessible from the containing module.
