import { CartItemInteface } from "./CartItemInteface";

export interface ProcessOrderInterface {
    customerID: number;
    cartItems: Array<CartItemInteface>;
}