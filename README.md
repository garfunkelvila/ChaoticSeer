# ChaoticSeer
This is basically just bad implementation of NEAT.

My attemp on ANN Library. My objective for this one is to learn more in C#. This is an ongoing project and most of functions don't work yet or don't exist.

When satisfied, I will also make a PHP (Class/Functions set), MSSQL (Functions set) and MySQL (Functions set) versions of it.

Currently it can't train to solve AND, NOT and XOR operators.

## Current classes
  * **Tribe** - Contains the population
  * **Neat** - Contains the NEAT functions and variables
  * **Activations** - Contains Activation functions
  * ~~**BackPropagation**~~ - Need to be converted to work with neat
  * **Mutation** - Contains Mutation functions
## Known working classes
  * Activations
    - [x] Logistic, TanH, Step and Relu are working (Others don't have derivatives to use with Back Propagation)
  * Genetics
    - [ ] Selection - Seer tribe sorting based score/fitness  on don't work yet
    - [x] Crossover
    - [x] Mutation - There is an issue of duplicate or non existing connection
	- [x] Connection
## Todo
  * Test the node limit
  * Export/Import Tribe
### Classes (Batch related)
  - **Country** - Contains tribe batch.
  * **Planet** - Contains Countries batch.
### Others
  * **Parser** - A kind of translator for network (numbers into binary, bitmap into RGB, and others)
  * **Population** - Start population, reproduction and aging related.
  * **Aging** - Able to make a specie naturally die
  * **LearningRateDecay** - Make learning rate slowly go down based on back propagation changes/variables, I still need to make a formula/flow for this one.
