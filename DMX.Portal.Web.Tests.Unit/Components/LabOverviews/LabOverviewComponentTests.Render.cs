﻿// --------------------------------------------------------------- 
// Copyright (c) Microsoft Corporation. All rights reserved. 
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Bunit;
using DMX.Portal.Web.Models.Views.LabViews;
using DMX.Portal.Web.Views.Components.DeviceOverviews;
using DMX.Portal.Web.Views.Components.LabOverviews;
using FluentAssertions;
using Xunit;

namespace DMX.Portal.Web.Tests.Unit.Components.LabOverviews
{
    public partial class LabOverviewComponentTests : TestContext
    {
        [Fact]
        public void ShouldHaveDefaultValues()
        {
            // given . when
            var initialLabOverviewComponent =
                new LabOverviewComponent();

            // then
            initialLabOverviewComponent.Lab.Should().BeNull();
            initialLabOverviewComponent.Details.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderLabDevicesAndDetails()
        {
            // given
            LabView randomLabView = CreateRandomLabView();
            LabView inputLabView = randomLabView;

            ComponentParameter inputComponentParameters =
               ComponentParameter.CreateParameter(
                   name: nameof(LabOverviewComponent.Lab),
                   value: inputLabView);

            // when
            this.renderedLabOverviewComponent =
                RenderComponent<LabOverviewComponent>(inputComponentParameters);

            // then
            this.renderedLabOverviewComponent.Instance.Lab
                .Should().BeEquivalentTo(inputLabView);
            
            this.renderedLabOverviewComponent.Instance.Details.Lab
                .Should().BeEquivalentTo(inputLabView);

            IEnumerable<IRenderedComponent<DeviceOverviewComponent>> allDeviceOverviewComponents =
                this.renderedLabOverviewComponent.FindComponents<DeviceOverviewComponent>();

            allDeviceOverviewComponents.Select(deviceOverviewComponent =>
                deviceOverviewComponent.Instance.Device)
                    .Should().BeEquivalentTo(inputLabView.Devices);
        }
    }
}