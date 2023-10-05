import { lazy, Suspense } from 'react';
import { Routes, Route } from 'react-router-dom';
import { Loader } from '@infrastructure/ui/components/layout/loader/Loader';
import { Page } from '@infrastructure/ui/components/Page';
import { Footer } from '@infrastructure/ui/components/layout/footer/Footer';
import { Header } from '@infrastructure/ui/components/layout/header/Header';

// TODO:
// Read https://reactrouter.com/en/main/routers/create-browser-router.
// Use the new 'createBrowserRouter' method if dynamic import ('lazy') is to be used.
// it also enables access to other APIs - loader, action, ...
const HomePage = lazy(() => import('@modules/facade/home/HomePage'));
type HomePageProps = React.ComponentProps<typeof HomePage>;
const homeProps: HomePageProps = {
    abc: "123",
}

const ambiTitle = (pageTitleKey: string) => `${pageTitleKey} - AmbiSocial`;

export const AppRoutes = () => {
    return (
        <section className='d-flex flex-column min-vh-100'>
            <Header />
            <Suspense fallback={<Loader />}>
                <Routes>
                    <Route
                        path='/'
                        element={<Page
                            title={'AmbiSocial - Where extroverts and introverts meet'}
                            component={{ Component: HomePage, props: homeProps, children: [<div key={1}>1</div>, <div key={2}>2</div>] }} />}
                    />
                    <Route path='/faq' element={<Page title={ambiTitle('FAQ')} component={{ Component: () => <div>Owing to the fact that</div> }} />} />
                </Routes>
            </Suspense>
            <Footer />
        </section>
    );
}