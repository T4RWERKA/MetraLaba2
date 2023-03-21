function heapSort(arr: number[]) {  
    let heapSize = arr.length;  
    buildMaxHeap(arr);  
    while (heapSize > 1) {  
        heapSize--;  
        swap(arr, 0, heapSize);  
        maxHeapify(arr, heapSize, 0);  
    }  
    return arr;  
}  
function buildMaxHeap(arr: number[]) {  
    const middle = Math.floor(arr.length / 2);  
    for (let i = middle; i >= 0; i--) {  
        maxHeapify(arr, arr.length, i);  
    }  
    console.log("if if if if if if if if if"); 
} 

if (1 == 1) {
    switch (day) { 
        case 0: 
            for (let i = 1; i <= 10; i++) {
                if (i < 5) {
                    console.log("i"); 
                } else {
                    console.log(i * i);
                }
            }
            break; 
        case 1:
            if (i > 0) {
                switch (i) {
                    case 1:
                        break;
                    case 2: 
                        i += 15;
                        break;
                }
            } else {
                if (i == 0) {
                    i++;
                    if (i == 1) {
                        i = 2;
                        if (i == 2) {
                            i = 16;
                        }
                    }          
                }
            }
            break;
        default: 
            break; 
    } 
} 
