/**
Core script to handle the entire theme and core functions
**/
var QuickSidebar = function () {

    // Handles quick sidebar toggler
    var handleQuickSidebarToggler = function () {
        // quick sidebar toggler
        $('.top-menu .dropdown-quick-sidebar-toggler a, .page-quick-sidebar-toggler').click(function (e) {
            $('body').toggleClass('page-quick-sidebar-open');
        });
    };

    //// Handles quick sidebar chats
    //var handleQuickSidebarChat = function () {
    //    // Declarando um proxy de referencia ao Hub
    //    var chatHub = $.connection.chat;

    //    var wrapper = $('.page-quick-sidebar-wrapper');
    //    var wrapperChat = wrapper.find('.page-quick-sidebar-chat');

    //    var initChatSlimScroll = (function slim() {
    //        var chatUsers = wrapper.find('.page-quick-sidebar-chat-users');
    //        var chatUsersHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();
    //        var chatUsersHeight;

    //        chatUsersHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

    //        // chat user list 
    //        Metronic.destroySlimScroll(chatUsers);
    //        chatUsers.attr("data-height", chatUsersHeight);
    //        Metronic.initSlimScroll(chatUsers);

    //        var chatMessages = wrapperChat.find('.page-quick-sidebar-chat-user-messages');
    //        var chatMessagesHeight = chatUsersHeight -
    //            wrapperChat.find('.page-quick-sidebar-chat-user-form').outerHeight() -
    //            wrapperChat.find('.page-quick-sidebar-nav').outerHeight();

    //        // user chat messages 
    //        Metronic.destroySlimScroll(chatMessages);
    //        chatMessages.attr("data-height", chatMessagesHeight);
    //        Metronic.initSlimScroll(chatMessages);

    //        return slim;
    //    })();

    //    Metronic.addResizeHandler(initChatSlimScroll); // reinitialize on window resize

    //    wrapper.find('.page-quick-sidebar-chat-users .media-list > .media')
    //        .click(function () {
    //            wrapperChat.addClass("page-quick-sidebar-content-item-shown");
    //        });

    //    wrapper.find('.page-quick-sidebar-chat-user .page-quick-sidebar-back-to-list')
    //        .click(function () {
    //            wrapperChat.removeClass("page-quick-sidebar-content-item-shown");
    //        });

    //    // Criando a função que será chamada pelo Hub para distribuir as mensagens aos clientes.
    //    // Por convenção as chamadas aos métodos são feitas em "camelCase"
    //    chatHub.client.transmitirMensagem = function (e, apelido, msg) {
    //        e.preventDefault();

    //        // Area do chat
    //        var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
    //        var input = wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control');

    //        var text = input.val();
    //        if (text.length === 0) {
    //            return;
    //        }

    //        var preparePost = function (dir, time, name, avatar, message) {
    //            var tpl = '';
    //            tpl += '<div class="post ' + dir + '">';
    //            tpl += '<img class="avatar" alt="" src="' + Layout.getLayoutImgPath() + avatar + '.jpg"/>';
    //            tpl += '<div class="message">';
    //            tpl += '<span class="arrow"></span>';
    //            tpl += '<a href="#" class="name">' + name + '</a>&nbsp;';
    //            tpl += '<span class="datetime">' + time + '</span>';
    //            tpl += '<span class="body">';
    //            tpl += message;
    //            tpl += '</span>';
    //            tpl += '</div>';
    //            tpl += '</div>';

    //            return tpl;
    //        };

    //        // Preparando postagem
    //        var time = new Date();
    //        var message = preparePost('out', (time.getHours() + ':' + time.getMinutes()), apelido, 'avatar3', msg);
    //        message = $(message);
    //        chatContainer.append(message);

    //        var getLastPostPos = function () {
    //            var getLastPostPos = function () {
    //                var height = 0;
    //                chatContainer.find(".post")
    //                    .each(function () {
    //                        height = height + $(this).outerHeight();
    //                    });

    //                return height;
    //            };

    //            chatContainer.slimScroll({
    //                scrollTo: getLastPostPos()
    //            });

    //            input.val("");
    //        };

    //        // Iniciando a conexão com o Hub
    //        $.connection.hub.start();

    //        wrapperChat.find('.page-quick-sidebar-chat-user-form .btn')
    //            .click(() => {
    //                chatHub.server.enviarMensagem(wrapperChat
    //                    .find('.page-quick-sidebar-chat-user-form .form-control')
    //                    .val(),
    //                    $("#nomeUsuario").val());
    //            });
    //        wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control')
    //            .keypress(function (e) {
    //                if (e.which == 13) {
    //                    chatHub.server.enviarMensagem(wrapperChat
    //                        .find('.page-quick-sidebar-chat-user-form .form-control')
    //                        .val(),
    //                        $("#nomeUsuario").val());
    //                    return false;
    //                }
    //            });
    //    };
    //};

    // Preparando quick sidebar tasks
    var handleQuickSidebarAlerts = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperAlerts = wrapper.find('.page-quick-sidebar-alerts');

        var initAlertsSlimScroll = function () {
            var alertList = wrapper.find('.page-quick-sidebar-alerts-list');
            var alertListHeight;

            alertListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // Lista de alertas
            Metronic.destroySlimScroll(alertList);
            alertList.attr("data-height", alertListHeight);
            Metronic.initSlimScroll(alertList);
        };

        initAlertsSlimScroll();
        Metronic.addResizeHandler(initAlertsSlimScroll); // Reiniciando quando redimencionar a janela
    };

    // Preparando configurações do quick sidebar
    var handleQuickSidebarSettings = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperAlerts = wrapper.find('.page-quick-sidebar-settings');

        var initSettingsSlimScroll = function () {
            var settingsList = wrapper.find('.page-quick-sidebar-settings-list');
            var settingsListHeight;

            settingsListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // Lista de alertas
            Metronic.destroySlimScroll(settingsList);
            settingsList.attr("data-height", settingsListHeight);
            Metronic.initSlimScroll(settingsList);
        };

        initSettingsSlimScroll();
        Metronic.addResizeHandler(initSettingsSlimScroll); // reinitialize on window resize
    };

    return {
        init: function () {
            //layout handlers
            handleQuickSidebarToggler(); // handles quick sidebar's toggler
            //handleQuickSidebarChat(); // handles quick sidebar's chats
            handleQuickSidebarAlerts(); // handles quick sidebar's alerts
            handleQuickSidebarSettings(); // handles quick sidebar's setting
        }
    };
}();