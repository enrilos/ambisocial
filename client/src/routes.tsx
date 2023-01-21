import { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";

import Header from "@components/header";
import Footer from "@components/footer";
import Loader from "@components/ui/loader";

import Page from "@components/utils/page";

const HomePage = lazy(() => import("@pages/home.page"));

const ambiTitle = (pageTitleKey: string) => `${pageTitleKey} - AmbiSocial`;

export default function AppRoutes() {
    return (
        <Suspense fallback={<Loader />}>
            <Header />
            <Routes>
                <Route path="/" element={<Page title={ambiTitle('Home')} component={HomePage} />} />
                <Route path="/why" element={(<>Owing to the fact that</>)} />
            </Routes>
            <Footer />
        </Suspense>
    );
}