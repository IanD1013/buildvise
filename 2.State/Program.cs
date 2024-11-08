
using _2.State;

Context context = new(new ConcreteStateA());

context.Request(); // state A
context.Request(); // state B -> A
context.Request(); // state A