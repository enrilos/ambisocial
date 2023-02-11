import { configureStore } from '@reduxjs/toolkit';
import counterReducer from '@app/store/counter.store';

const reducer = {
    counter: counterReducer
};

const preloadedState = JSON.parse(localStorage.getItem('redux') ?? '{}');

/*const persistStoreMiddleware = (store: any) => (next: any) => (action: any) => {
    localStorage.setItem('redux', JSON.stringify({ ...store.getState(), ...action.payload }));
    next(action);
}*/

export const store = configureStore({
    reducer,
    /*middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(persistStoreMiddleware),*/
    preloadedState
});

// TODO: Refactor and use a debouncer.
store.subscribe(() => {
    localStorage.setItem('redux', JSON.stringify(store.getState()));
});

export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch