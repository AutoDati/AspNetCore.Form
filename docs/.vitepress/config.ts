import { defineConfig } from "vitepress";

export default defineConfig({
  lang: "en-US",
  title: "AspNetCore.Form",
  description: "Generate Form Schemas from source code",

  lastUpdated: true,

  themeConfig: {
    nav: nav(),

    sidebar: {
      "/guide/": sidebarGuide(),
      "/options/": sidebarOptions(),
    },

    editLink: {
      pattern:
        "https://github.com/emersonbottero/AspNetCore.Form/edit/main/docs/:path",
      text: "Edit this page on GitHub",
    },

    socialLinks: [
      {
        icon: "github",
        link: "https://github.com/emersonbottero/AspNetCore.Form",
      },
    ],

    footer: {
      message: "Released under the MIT License.",
      copyright: "Copyright © 2022-present Emerson Bottero",
    },
  },
});

function nav() {
  return [
    { text: "Guide", link: "/guide/", activeMatch: "/guide/" },
    { text: "Options", link: "/options/", activeMatch: "/options/" },
    {
      text: "Changelog",
      link: "https://github.com/emersonbottero/AspNetCore.Form/blob/main/CHANGELOG.md",
    },
  ];
}

function sidebarGuide() {
  return [
    {
      text: "Introduction",
      collapsible: true,
      items: [
        { text: "Getting Started", link: "/guide/" },
        {
          text: "What is AspNetCore.Form?",
          link: "/guide/what-is-aspnetcore-form",
        },
      ],
    },
  ];
}

function sidebarOptions() {
  return [
    {
      text: "Options",
      items: [
        { text: "Introduction", link: "/options/" },
        { text: "Custom Attributes", link: "/options/custom-attributes" },
        { text: "Attributes Computed", link: "/options/attributes" },
      ],
    },
  ];
}
