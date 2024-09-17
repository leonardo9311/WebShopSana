import { ProcessOrderInterface } from "../../interfaces/processOrdeerInterface";
import { Product } from "../../interfaces/productInterface";

export class ProductService {
    private baseUrl: string;

    constructor() {
        
        this.baseUrl = import.meta.env.VITE_API_BASE_URL || '';
        console.log(this.baseUrl);
    }

    async getProducts(pageNumber: number, pageSize: number): Promise<Product[]> {
      
        const response = await fetch(`${this.baseUrl}/api/Products?pageNumber=${pageNumber}&pageSize=${pageSize}`);
       
        if (!response.ok) {
            throw new Error('Failed to fetch products');
        }
        return response.json();
    }

    async processOrder(orderData: ProcessOrderInterface): Promise<any> {
        const response = await fetch(`${this.baseUrl}/api/Orders/ProcessOrder`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify( orderData ),
        });

        if (!response.ok) {
            throw new Error('Failed to process order');
        }

        return response.json();
    }


    async checkProductStock(productId: number, requestedQuantity: number): Promise<boolean> {
        try {
     
            const response = await fetch(`${this.baseUrl}/api/products/${productId}/check-stock?quantity=${requestedQuantity}`);

            if (!response.ok) {
                throw new Error('Failed to check product stock');
            }

            const data = await response.json();
            return data.isAvailable; 
        } catch (error) {
            console.error('Error checking product stock:', error);
            throw error; 
        }
    }
}
