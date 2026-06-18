import ErrorHandler from '@/components/ErrorHandler';
import FormVariantEditor from '@/components/FormVariantEditor';
import ModalViewExport from '@/components/ModalViewExport';
import { BoilerCalculationResponse } from '@/constants/typing';
import { CalculationReport } from '@/services/CalculationReport';
import { PDFDownloadLink } from '@react-pdf/renderer';
import { Access, useAccess, history, useModel, request, Link } from '@umijs/max';
import { Button, Form, Input, message, Space } from "antd";
import { useEffect } from "react";
import KotelCalcImg from '@/assets/kotelUt/Calculate.png';
import KotelListImg from '@/assets/kotelUt/List.png';
import CardLinkHandler from '@/components/CardLink/CardLinkHandler';
import './homePage.css';
import { UserOutlined } from '@ant-design/icons';

type CardInform = { urla: string, caption?: string, description?: string, imgLink?: string }

export default function HomePage() {

  const access = useAccess();
  const { refresh } = useModel('@@initialState');
  // const calculateKotelUtiliz = () => {
  //   history.push('/calculate');
  // };
  // const listKotelUtiliz = () => {
  //   history.push('/kotelList');
  // };


  const LinkData = [
    {
      creator: "Филипенко Никита",
      isWork: true,
      caption: "Котёл-Утилизатор",
      links: [
        {
          url: "/calculateKU",
          caption: 'Расчитать',
          description: 'Сделать расчёт',
          imgLink: KotelCalcImg
        },
        {
          url: "/kotelList",
          caption: 'Менеджмент данных',
          description: 'Просмотр данных пользователя',
          imgLink: KotelListImg
        }
      ]
    },
    {
      creator: "Васильева Вероника",
      isWork: false,
      caption: "Водяное охлаждение редуктора",
      links: [
        // {
        //   url: "/calculateWC",
        //   caption: 'Расчитать',
        // },
        // {
        //   url: "/WCList",
        //   caption: 'Лист данных',
        // }
      ]
    },
    {
      creator: "Киреев Николай",
      isWork: false,
      caption: "Петлевой металлический рекуператор",
      links: [
        // {
        //   url: "/calculateMR",
        //   caption: 'Расчитать',
        // },
        // {
        //   url: "/MRList",
        //   caption: 'Лист данных',
        // }
      ]
    },
    {
      creator: "Крашенинников Ян",
      isWork: false,
      caption: "Игольчатый рекуператор",
      links: [
        // {
        //   url: "/calculateNR",
        //   caption: 'Расчитать',
        // },
        // {
        //   url: "/NRList",
        //   caption: 'Лист данных',
        // }
      ]
    },
    {
      creator: "Соловьёв Александр",
      isWork: false,
      caption: "Керамический рекуператор",
      links: [
        // {
        //   url: "/calculateСR",
        //   caption: 'Расчитать',
        // },
        // {
        //   url: "/СRList",
        //   caption: 'Лист данных',
        // }
      ]
    },
    {
      creator: "Водопьянов Виктор",
      isWork: true,
      caption: "Керамический рекуператор",
      links: [
        // {
        //   url: "/calculateNR",
        //   caption: 'Расчитать',
        // },
        // {
        //   url: "/NRList",
        //   caption: 'Лист данных',
        // }
      ]
    },

  ]

  return (

    <>
      <h1>Главная страница</h1>
      <Access accessible={access.isAuth}>
        {LinkData.map((item, index) => (
          <div className='cathegoryPlace'>
            <div className='CaptionLn'>
              <div className="captContainer">
                <p className='CaptionCathegory'>
                  {item.caption}
                </p>
                <p className='creatorCapt'>{<UserOutlined />} {item.creator ?? "Кто-то"}</p>
              </div>
              <div className='lineCaption' />
            </div>
            <div style={{ display: 'flex', justifyContent: 'space-between' }}>
              {item.links.length > 0 ? (
                item.links.map((items, indexs) => (
                  <CardLinkHandler
                    key={indexs} // Обязательно добавляем key для итераций в React
                    url={items.url}
                    caption={items.caption}
                    description={items.description}
                    imgLink={items.imgLink}
                  />
                ))
              ) : (
                <div className="NoFoundCP">Пусто</div>
              )}
            </div>
          </div>

        ))}

      </Access>
      <Access accessible={!access.isAuth}>
        <p>Необходимо авторизоваться, чтобы использовать сайт!</p>
      </Access>

    </>
  )
};
