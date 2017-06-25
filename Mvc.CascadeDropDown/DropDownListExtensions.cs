﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropDownListExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The drop down list extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mvc.CascadeDropDown
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using Mvc.CascadeDropDown.Infrastructure;

    /// <summary>
    ///     The drop down list extensions.
    /// </summary>
    public static class DropDownListExtensions
    {
        /// <summary>
        /// The cascading drop down list.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="inputName">
        /// The input name.
        /// </param>
        /// <param name="inputId">
        /// The input id.
        /// </param>
        /// <param name="triggeredByProperty">
        /// The triggered by property.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// </typeparam>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static MvcHtmlString CascadingDropDownList<TModel, TProperty>(
            this HtmlHelper htmlHelper,
            string inputName,
            string inputId,
            Expression<Func<TModel, TProperty>> triggeredByProperty,
            string url,
            string ajaxActionParamName,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            object htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {
            var triggerMemberInfo = Utils.GetMemberInfo(triggeredByProperty);
            if (triggerMemberInfo == null)
            {
                throw new ArgumentException("triggeredByProperty argument is invalid");
            }

            return CascadingDropDownList(
                htmlHelper,
                inputName,
                inputId,
                triggerMemberInfo.Name,
                url,
                ajaxActionParamName,
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes,
                options);
        }

        /// <summary>
        /// The cascading drop down list.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="inputName">
        /// The input name.
        /// </param>
        /// <param name="inputId">
        /// The input id.
        /// </param>
        /// <param name="triggeredByProperty">
        /// The triggered by property.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString CascadingDropDownList(
            this HtmlHelper htmlHelper,
            string inputName,
            string inputId,
            string triggeredByProperty,
            string url,
            string ajaxActionParamName,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            object htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {
            return CascadingDropDownList(
                htmlHelper,
                inputName,
                inputId,
                triggeredByProperty,
                url,
                ajaxActionParamName,
                Utils.GetPropStringValue(htmlHelper.ViewData.Model, inputName),
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : new RouteValueDictionary(),
                options);
        }

        /// <summary>
        /// The cascading drop down list.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="inputName">
        /// The input name.
        /// </param>
        /// <param name="inputId">
        /// The input id.
        /// </param>
        /// <param name="triggeredByProperty">
        /// The triggered by property.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString CascadingDropDownList(
            this HtmlHelper htmlHelper,
            string inputName,
            string inputId,
            string triggeredByProperty,
            string url,
            string ajaxActionParamName,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            RouteValueDictionary htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {
            return CascadingDropDownList(
                htmlHelper,
                inputName,
                inputId,
                triggeredByProperty,
                url,
                ajaxActionParamName,
                Utils.GetPropStringValue(htmlHelper.ViewData.Model, inputName),
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes,
                options);
        }

        /// <summary>
        /// The cascading drop down list for.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="triggeredByProperty">
        /// The triggered by property.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <typeparam name="TModel">
        /// Type of model
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// Type of property in the model
        /// </typeparam>
        /// <typeparam name="TProperty2">
        /// Type of property in the model
        /// </typeparam>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static MvcHtmlString CascadingDropDownListFor<TModel, TProperty, TProperty2>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Expression<Func<TModel, TProperty2>> triggeredByProperty,
            string url,
            string ajaxActionParamName,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            object htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {
            var triggerMemberInfo = Utils.GetMemberInfo(triggeredByProperty);
            var dropDownElement = Utils.GetMemberInfo(expression);

            if (dropDownElement == null)
            {
                throw new ArgumentException("expression argument is invalid");
            }

            if (dropDownElement == null)
            {
                throw new ArgumentException("triggeredByProperty argument is invalid");
            }

            var dropDownElementName = dropDownElement.Name;
            var dropDownElementId = Utils.GetDropDownElementId(htmlAttributes) ?? dropDownElement.Name;

            return CascadingDropDownList(
                htmlHelper,
                dropDownElementName,
                dropDownElementId,
                triggerMemberInfo.Name,
                url,
                ajaxActionParamName,
                Utils.GetPropStringValue(htmlHelper.ViewData.Model, expression),
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : new RouteValueDictionary(),
                options);
        }

        /// <summary>
        /// The cascading drop down list for.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="triggeredByPropertyWithId">
        /// The triggered by property with id.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <typeparam name="TModel">
        /// Type of model
        /// </typeparam>
        /// <typeparam name="TProperty">
        /// Type of property in the model
        /// </typeparam>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if case that expression is invalid and could not be resolved
        /// </exception>
        public static MvcHtmlString CascadingDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string triggeredByPropertyWithId,
            string url,
            string ajaxActionParamName,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            object htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {
            var dropDownElement = Utils.GetMemberInfo(expression);

            if (dropDownElement == null)
            {
                throw new ArgumentException("expression argument is invalid");
            }

            var dropDownElementName = dropDownElement.Name;
            var dropDownElementId = Utils.GetDropDownElementId(htmlAttributes) ?? dropDownElement.Name;

            return CascadingDropDownList(
                htmlHelper,
                dropDownElementName,
                dropDownElementId,
                triggeredByPropertyWithId,
                url,
                ajaxActionParamName,
                Utils.GetPropStringValue(htmlHelper.ViewData.Model, expression),
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : new RouteValueDictionary(),
                options);
        }

        /// <summary>
        /// The cascading drop down list.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="inputName">
        /// The input name.
        /// </param>
        /// <param name="cascadeDdElementId">
        /// The cascade dd element id.
        /// </param>
        /// <param name="triggeredByProperty">
        /// The triggered by property.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="ajaxActionParamName">
        /// The ajax action param name.
        /// </param>
        /// <param name="selectedValue">
        /// The selected value.
        /// </param>
        /// <param name="optionLabel">
        /// The option label.
        /// </param>
        /// <param name="disabledWhenParentNotSelected">
        /// The disabled when parent not selected.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        private static MvcHtmlString CascadingDropDownList(
            this HtmlHelper htmlHelper,
            string inputName,
            string cascadeDdElementId,
            string triggeredByProperty,
            string url,
            string ajaxActionParamName,
            string selectedValue,
            string optionLabel = null,
            bool disabledWhenParentNotSelected = false,
            RouteValueDictionary htmlAttributes = null,
            CascadeDropDownOptions options = null)
        {

            Func<string, IDictionary<string, object>, string, string> defaultDropDownFactory = (input, attributesDictionary, optLbl)
                => htmlHelper.DropDownList(input, new List<SelectListItem>(), optLbl, attributesDictionary).ToString();

            return new MvcHtmlString(CascadeDropDownCreator.Create(
                defaultDropDownFactory,
                inputName,
                cascadeDdElementId,
                triggeredByProperty,
                url,
                ajaxActionParamName,
                selectedValue,
                optionLabel,
                disabledWhenParentNotSelected,
                htmlAttributes,
                options));
        }
    }
}