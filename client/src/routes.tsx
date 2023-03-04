import { lazy, Suspense } from 'react';
import { Routes, Route } from 'react-router-dom';

import Footer from '@components/footer';
import Loader from '@components/ui/loader';

import Page from '@components/utils/page';

const HomePage = lazy(() => import('@pages/home.page'));

const ambiTitle = (pageTitleKey: string) => `${pageTitleKey} - AmbiSocial`;

export default function AppRoutes() {
    return (
        <section className='d-flex flex-column min-vh-100'>
            <Suspense fallback={<Loader />}>
                <Routes>
                    <Route path='/' element={<Page title={'AmbiSocial - Where extroverts and introverts meet'} component={HomePage} />} />
                    <Route path='/discover' element={<Page title={ambiTitle('Discover')} component={() => <div>Discover like-minded people</div>} />} />
                    <Route path='/why' element={<Page title={ambiTitle('Why')} component={() => <div>Owing to the fact that</div>} />} />
                </Routes>
                <Footer />
            </Suspense>
        </section>
    );
}