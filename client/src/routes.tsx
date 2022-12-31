import { Routes, Route } from "react-router-dom";
import Header from "@components/header";
import Footer from "@components/footer";
import HomePage from "@pages/home.page";

export default function AppRoutes() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/why/abc" element={(<>Owing to the fact that</>)} />
            </Routes>
            <Footer />
        </>
    );
}