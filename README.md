# ChaoticSeer
This is basically just bad implementation of NEAT.

My attemp on ANN Library. My objective for this one is to learn more in C#. This is an ongoing project and most of functions don't work yet or don't exist.

When satisfied, I will also make a PHP (Class/Functions set), MSSQL (Functions set) and MySQL (Functions set) versions of it.

Currently it can't train to solve AND, NOT and XOR operators.

## Current classes
  * **Tribe** - Contains the population
  * **Neat** - Contains the NEAT functions and variables
  * **Activations** - Contains Activation functions
  * ~~**BackPropagation** - Need to be converted to work with neat~~
  * **Mutation** - Contains Mutation functions
## Known working classes
  * Activations
    - [x] Logistic, TanH, Step and Relu are working (Others don't have derivatives to use with Back Propagation)
  * Genetics
    - [ ] Selection
    - [x] Crossover
    - [x] Mutation
	- [x] Connection
## Todo
  * Test the node limit
### Classes (Batch and threading related)
  - **Country** - Contains Species/batch
  * **Planet** - Contain Countries, will be used for mini batch. Will do it like this because I will make some gender mutation and mini batch mutate limitations.
  * **GenericSeer** - Just a seer constructor that only asks for input and output count. Layers, Neuron count will be based on system specs, input count and output count.
### Others
  * **LearningRateDecay** - Make learning rate slowly go down based on back propagation changes/variables, I still need to make a formula/flow for this one.
  * **Parser** - A kind of translator for network (numbers into binary, bitmap into RGB, and others)
  * **Aging** - A kind of natural selection without purging
