import { combineReducers, configureStore } from '@reduxjs/toolkit';
import counterReducer from '@app/store/counter.store';
import storage from 'redux-persist/lib/storage';
import persistReducer from 'redux-persist/es/persistReducer';

const reducers = combineReducers({
    counter: counterReducer
});

const persistConfig = {
    key: 'root',
    storage: storage,
    whitelist: ['counter']
};

const persistedReducer = persistReducer(persistConfig, reducers);

export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({
        serializableCheck: false
    }),
});

export type RootState = ReturnType<typeof store.getState>

export type AppDispatch = typeof store.dispatch