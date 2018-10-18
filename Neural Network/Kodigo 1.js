//  cost = diff^2
//  diff = pred - target
//  pred = sigmoid(z)
//     z = (weight_1 * input_1) + (weight_2 * input_2) + (weight_3 * input_3) .......... 

//THIS THING IS FROM A YOUTUBE CHANNEL I JUST BASE HERE THEN MODIFY IT BASED ON WHAT I WANT xD

//training set. [length, width, color(0=blue and 1=red)]
var dataB1 = [1, 1, 0];
var dataB2 = [2, 1, 0];
var dataB3 = [2, .5, 0];
var dataB4 = [3, 1, 0];

var dataR1 = [3, 1.5, 1];
var dataR2 = [3.5, .5, 1];
var dataR3 = [4, 1.5, 1];
var dataR4 = [5.5, 1, 1];

//unknown type (data we want to find)
var dataU = [4.5, 1, "it should be 1"];

var all_points = [dataB1, dataB2, dataB3, dataB4, dataR1, dataR2, dataR3, dataR4];

function sigmoid(x) {
    return 1 / (1 + Math.exp(-x));
}

// training
function train() {
    let w1 = Math.random() * .2 - .1;
    let w2 = Math.random() * .2 - .1;
    let b = Math.random() * .2 - .1;
    let learning_rate = 0.2;
    for (let iter = 0; iter < 50000; iter++) {
        // pick a random point
        let random_idx = Math.floor(Math.random() * all_points.length);
        let point = all_points[random_idx];
        let target = point[2]; // target stored in 3rd coord of points

        // feed forward
        let z = w1 * point[0] + w2 * point[1] + b;
        let pred = sigmoid(z);

        // now we compare the model prediction with the target
        let cost = (pred - target) ** 2;

        // now we find the slope of the cost w.r.t. each parameter (w1, w2, b)
        // bring derivative through square function
        let dcost_dpred = 2 * (pred - target);

        // bring derivative through sigmoid
        // derivative of sigmoid can be written using more sigmoids! d/dz sigmoid(z) = sigmoid(z)*(1-sigmoid(z))
        let dpred_dz = sigmoid(z) * (1 - sigmoid(z));

        // I think you forgot these in your slope calculation? 
        let dz_dw1 = point[0];
        let dz_dw2 = point[1];
        let dz_db = 1;

        // now we can get the partial derivatives using the chain rule
        // notice the pattern? We're bringing how the cost changes through each function, first through the square, then through the sigmoid
        // and finally whatever is multiplying our parameter of interest becomes the last part
        let dcost_dw1 = dcost_dpred * dpred_dz * dz_dw1;
        let dcost_dw2 = dcost_dpred * dpred_dz * dz_dw2;
        let dcost_db = dcost_dpred * dpred_dz * dz_db;

        // now we update our parameters!
        w1 -= learning_rate * dcost_dw1;
        w2 -= learning_rate * dcost_dw2;
        b -= learning_rate * dcost_db;
    }

    return { w1: w1, w2: w2, b: b };
}