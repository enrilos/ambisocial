import { useSelector } from "react-redux";
import { CounterState } from "./counter.store";

export function useCounter(): CounterState {
    return useSelector((state: any) => state.counter);
}