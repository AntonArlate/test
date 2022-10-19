// найти длину наибольшей общей подпоследовательности
// 1 2 3 5 6 1 2 3 1 1 1 1
// 1 2 5 3 6 1 2 1 1 1 2 4 6 1

public class program {
    public static void main(String[] args) {
        int[] arr1 = {1, 2, 3, 5, 6, 1, 2, 3, 1, 1, 1, 1};
        int[] arr2 = {1, 2, 5, 3, 6, 1, 2, 1, 1, 1, 2, 4, 6, 1};
        int count = 0;

        for (int i = 0; i < arr1.length; i++) {
            System.out.println();
            finder(arr2, arr1, i, 0);
        }
        

        System.out.println(count);
        

    }


    static void finder (int arr_l[],int[] arr_s, int i_s, int i_l) {
        while (i_l < arr_l.length) {
            if (arr_s[i_s] == arr_l[i_l]) {
                // count++;
                if (i_s+1>=arr_s.length) {
                    // return count;
                }

                else {
                    if (i_l+1<arr_l.length) {
                        System.out.printf("%d", arr_s[i_s]);
                        finder(arr_l, arr_s, i_s+1, i_l+1);
                        return;
                        
                    }
            
                    else {
                        System.out.println();
                        finder(arr_l, arr_s, i_s+1, 0);
                        return;
                    }
                }
            }
            i_l++;
        }



    }


}