# SWAP POOL SCANNER

## OBJECTIVE
Scan a ETH-based network's swap contracts for their pool pairs.

## FEATURES

### **SCAN**
Scans the network between two indexes for all the pairs and their tokens. It's possible to attempt a recovery request if the request fail and, as a last case, skip failed attempts (see ScanRequest).

### **UPDATE**
Updates an existing list of pairs as long as the pair. It's possible to attempt a recovery request if the request fail and, as a last case, skip failed attempts (see UpdateRequest).

### **COUNT**
The number of pairs that exist in the network.

### **PAIR**
Fetches a pair and their tokens. As a two-step process, it can fail. It's possible to attempt a recovery request if the request fail and, as a last case, skip failed attempts (see PairRequest).

## ARCHITECTURE
The solution is composed by a library (Crypto.Eth.Pool.SwapScanner) located at the API folder. A support API and a REDIS data source are provided but both are disposable. 

## MODELS
### **SWAP SCANNER SETTINGS**

**RPC URL** - URL used to interact with a network node.

**FACTORY ADDRESS** - The factory's contract address.


### **PAIR REQUEST**


### **PAIR**

### **SCAN REQUEST**

### **UPDATE REQUEST**


## HOW TO USE 

### LIBRARY
1. Extract the library folder to the solution and add it as a project.

### SOLUTION
1. Install docker
2. Run docker compose build
3. Run docker compose up
4. Access through localhost:8080

*If the factory contract or the RPC URL are different, change them in the docker-compose yml*

