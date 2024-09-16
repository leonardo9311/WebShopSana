import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { addItemToCart, updateItemQuantityAsync, removeItemAsync } from '../actions/cartActions';
import { Product } from '../../services/product/productInterfaca';

interface CartItem {
    id: number;
    title: string;
    productCode: string;
    price: number;
    quantity: number;
    stockQuantity: number;
}

interface CartState {
    items: CartItem[];
}

const initialState: CartState = {
    items: [],
};

const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(addItemToCart.fulfilled, (state, action: PayloadAction<Product>) => {
                const existingItem = state.items.find(item => item.id === action.payload.productID);
                if (existingItem) {
                    existingItem.quantity += 1;
                } else {
                    // Add the product to the cart with an initial quantity of 1
                    state.items.push({
                        id: action.payload.productID,
                        title: action.payload.title,
                        productCode: action.payload.productCode,
                        price: action.payload.price,
                        stockQuantity: action.payload.stockQuantity,
                        quantity: 1,
                    });
                }
            })
            .addCase(updateItemQuantityAsync.fulfilled, (state, action: PayloadAction<{ productId: number; quantity: number }>) => {
                const item = state.items.find(item => item.id === action.payload.productId);
                if (item) {
                    item.quantity = action.payload.quantity;
                }
            })
            .addCase(removeItemAsync.fulfilled, (state, action: PayloadAction<number>) => {
                state.items = state.items.filter(item => item.id !== action.payload);
            });
    },
});

export default cartSlice.reducer;
