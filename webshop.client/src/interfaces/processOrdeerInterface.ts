
import { ProductToSendDTO } from '../interfaces/productToSendDTO';
export interface ProcessOrderInterface {
    customerID: number;
    cartItems: ProductToSendDTO[];
}