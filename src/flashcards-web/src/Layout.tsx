import Footer from "./components/Footer";
import Header from "./components/Header";

type LayoutProps = {
  children: React.ReactNode;
};

function Layout(props: LayoutProps) {
  return (
    <>
      <Header />
      {props.children}
      <Footer />
    </>
  );
}

export default Layout;
