import { Link, Outlet, useLocation, history, matchRoutes  } from 'umi';
import './index.css';
import { Form, Input, Button, Card, Typography, message } from 'antd';
import { UserOutlined, HomeOutlined } from '@ant-design/icons';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import JoinLogicButton from '@/components/JoinLogicButton';

const { Header, Content, Footer } = Layout;

const items = [
  {
    key: 'home',
    label: <Link to="/">Добавить новые данные</Link>
  },
  {
    key: 'studentsList',
    label: <Link to="/studentsList">СРД</Link>
  },
  // {
  //   key: 'join',
  //   label: <Link to="/join">Войти</Link>
  // }
]


export default function LayoutPage() {
  return (

    <Layout style={{minHeight: '100vh'}}>
      <Header style={{ display: 'flex', alignItems: 'center' }} className="main-header">
        <div style={{display: 'flex', alignItems: 'center'}}>     
          <Link to="/home" className='main-logo'><HomeOutlined /> {document.title}</Link>
          {/* <Menu
            //theme="dark"
            mode="horizontal"
            defaultSelectedKeys={['2']}
            items={items}
            className="main-menu"
          /> */}
        </div>
        <JoinLogicButton />
      </Header>
      <Content style={{ padding: '0 48px' }}>
        <div style={{ marginTop: 25 }} />
        {/* <Breadcrumb
          style={{ margin: '16px 0' }}
          items={[{ title: 'Home' }, { title: 'List' }, { title: 'App' }]}
        /> */}
        <div
        // style={{
        //   background: colorBgContainer,
        //   minHeight: 280,
        //   padding: 24,
        //   borderRadius: borderRadiusLG,
        // }}
        >
          <Outlet />
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>
        Someone is somewhere out there | {new Date().getFullYear()}
      </Footer>
    </Layout>

    // <div className={styles.navs}>
    //   <ul>
    //     <li>
    //       
    //     </li>
    //     <li>
    //       
    //     </li>
    //     <li>
    //       <a href="https://github.com/umijs/umi">Github</a>
    //     </li>
    //   </ul>
    //   <Outlet />
    // </div>
  );
}
