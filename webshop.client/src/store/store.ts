// store.ts

import { configureStore, combineReducers } from '@reduxjs/toolkit';
import cartReducer from './reducers/cartSlice';
import notificationReducer from './reducers/notificationSlice'; 


const rootReducer = combineReducers({
    cart: cartReducer,
    notification: notificationReducer
});


const preloadedState = {
    cart: {
        items: JSON.parse(localStorage.getItem('cart') || '[]'),
    },
};


const store = configureStore({
    reducer: rootReducer,
    preloadedState,
    devTools: process.env.NODE_ENV !== 'production',
});


store.subscribe(() => {
    localStorage.setItem('cart', JSON.stringify(store.getState().cart.items));
});

export type RootState = ReturnType<typeof rootReducer>;
export type AppDispatch = typeof store.dispatch;
export default store;
