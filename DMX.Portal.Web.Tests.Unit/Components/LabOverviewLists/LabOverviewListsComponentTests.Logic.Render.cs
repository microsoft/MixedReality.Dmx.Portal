﻿// --------------------------------------------------------------- 
// Copyright (c) Microsoft Corporation. All rights reserved. 
// ---------------------------------------------------------------

using DMX.Portal.Web.Views.Components.LabOverviewLists;
using FluentAssertions;
using Xunit;

namespace DMX.Portal.Web.Tests.Unit.Components.LabOverviewLists
{
    public partial class LabOverviewListsComponentTests
    {
        [Fact]
        public void ShouldRenderDefaultValues()
        {
            // given . when
            var initialRenderedLabOverviewListsComponent = new LabOverviewListsComponent();

            // then
            initialRenderedLabOverviewListsComponent.Labs
                .Should().BeNull();
        }

        [Fact]
        public void LabViewServiceShouldNotBeNull()
        {
            // given .when
            this.renderedLabOverviewListsComponent = RenderComponent<LabOverviewListsComponent>();

            // then
            this.renderedLabOverviewListsComponent.Instance.LabViewService
                .Should().NotBeNull();
        }

        [Fact]
        public void LabViewsShouldNotBeNull()
        {
            // given .when
            this.renderedLabOverviewListsComponent = RenderComponent<LabOverviewListsComponent>();

            // then
            this.renderedLabOverviewListsComponent.Instance.Labs
                .Should().NotBeNull();
        }
    }
}
