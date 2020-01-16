# DarkSeer
My attemp on ANN Library. My objective for this one is to learn more in C#. This is an ongoing project and most of functions don't work yet or don't exist.

When satisfied, I will also make a PHP (Class/Functions set), MSSQL (Functions set) and MySQL (Functions set) versions of it.

Currently it can train to solve AND, NOT and XOR operators.

## Current classes
  * **Neuron** - Contains Weights and Bias
  * **NeuronLayer** - Contains neurons
  * **NeuronLayerGroup** - Contains Neuron Layers
  * **Activations** - Contains Activation functions
  * **BackPropagation** - Contains Back Propagation functions
  * **Genetics** - Contains Mutation functions
## Known working classes
  * Neuron
    - [x] Axon/Output
  * NeuronLayer
    - [x] This is just a container with some fields
  * NeuronLayerGroup
    - [x] Forward feed
  * Activations
    - [x] Logistic, TanH, Step and Relu are working
  * BackPropagation
    - [x] Gradient Descent BackPropagate (Tested on 2 layers 2 input and one output)
  * Genetics
    - [ ] NeuronLayerGroup mutation functions
    - [ ] CNS mutation functions
    - [ ] Mutate Different NeuronLayerGroup layout
## Todo
  * **NeuronLayerGroup** - Change the mutation into sum instead of copy. This will make the bias and weight greater than its random range.
### Classes (Minibatch related)
  * **Country** - Contains Species/batch
  * **Planet** - Contain Countries, will be used for mini batch. Will do it like this because I will make some gender mutation and mini batch mutate limitations.
  * **GenericSeer** - Just a seer constructor that only asks for input and output count. Layers, Neuron count will be based on system specs, input count and output count.
### Others
  * **LearningRateDecay** - Make learning rate slowly go down based on back propagation changes/variables, I still need to make a formula for this one.
  * **Fitness** - Will hold generic fitness functions (Probably won't be needed as each specie will hold fitness field).
  * **Parser** - A kind of translator for network (numbers into binary, bitmap into RGB, and others)
