package app.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

import javax.servlet.http.HttpSession;
import java.util.ArrayList;
import java.util.List;

@Controller
public class HomeController {

    @RequestMapping(value = "/index", method = RequestMethod.GET)
    public String index(HttpSession httpSession, Model model) {
        List<String> items = (ArrayList<String>) httpSession.getAttribute("list");
        model.addAttribute("items", items);

        return "index";
    }

    @RequestMapping(value = "/index", method = RequestMethod.POST)
    public String addItem(HttpSession httpSession, @RequestParam("newItem") String item) {
        List<String> items = (ArrayList<String>) httpSession.getAttribute("list");

        if (items == null) {
            items = new ArrayList<>();
        }

        items.add(item);

        httpSession.setAttribute("list", items);
        return "redirect:index";
    }
}
