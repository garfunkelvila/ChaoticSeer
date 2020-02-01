# NiceSeer
This branch is for converting the whole seer to be compatible with neat so I can impelement it here.
I just realized that what I want to do is called NEAT

## Current classes
  * **Neuron** - Contains Weights and Bias
  * **NeuronLayer** - Contains neurons (Will be deleted)
  * **NeuronLayerGroup** - Contains Neuron Layers (Will be deleted)
  * **Activations** - Contains Activation functions
  * **BackPropagation** - Contains Back Propagation functions (Will be revised to work with neat)
  * **Genetics** - Contains Mutation functions (Will be elaborated)
## Known working classes
  * Neuron
    - [x] Axon/Output
  * Genome
    - [x] Forward feed (Will be revised to use with node and connections)
  * Activations
    - [x] Logistic, TanH, Step and Relu are working (Others don't have derivatives to use with Back Propagation)
  * BackPropagation
    - [x] Gradient Descent BackPropagate (Will be revised, error propagation formula will change after the connection and nodes are done)
  * Genetics
    - [ ] Selection
    - [ ] Crossover
    - [ ] Mutation
	- [ ] Connection
## Todo
  * A thing that can contain connections, and match if current connection exists. Probably will be inserted in seer/neat 
  * **Normalze Weight** - (Mutation) Re center the weights and biases of the neurons before mutation. May or may not be needed
### Classes (Batch and threading related)
  - **Country** - Contains Species/batch
  * **Planet** - Contain Countries, will be used for mini batch. Will do it like this because I will make some gender mutation and mini batch mutate limitations.
  * **GenericSeer** - Just a seer constructor that only asks for input and output count. Layers, Neuron count will be based on system specs, input count and output count.
### Others
  * **LearningRateDecay** - Make learning rate slowly go down based on back propagation changes/variables, I still need to make a formula/flow for this one.
  * **Parser** - A kind of translator for network (numbers into binary, bitmap into RGB, and others)
  * **MutationRate** - Mutation rate will be fixed every specie. And will be affected by mutation
