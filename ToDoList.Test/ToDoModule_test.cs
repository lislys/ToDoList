using System;
using System.Collections.Generic;
using ToDoList.CRUD;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace ToDoList.Test
{
    public class ToDoModule_test
    {
        [Fact]
        public void TestGetAll_returnOK()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/to-do-list/", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void TestAdd()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var tid = DateTime.Now;

            // When
            var result = browser.Post("/to-do/", with =>
            {
                with.HttpRequest();
                //with.JsonBody();
                with.Query("Title", "Titel");
                with.Query("Deadline", "2019-03-01");
                with.Query("Description", "En god beskrivelse");
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
